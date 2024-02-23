
//http://localhost:5188/PaginaCrud.html
//http://localhost:5188/api/departamentos
//http://localhost:5188/api/personas

window.onload = InicializaEventos;

//elementos html
var misDeps;
var misPersonas;
var miP;

//variables globales
var listaDeps;
var listaPersonas;

async function InicializaEventos() {
    misPersonas = document.getElementById("listaPersonas");
    miP = document.getElementById("textoCarga");

    await PeticionDeps();
    await PeticionPersonas();

    CargarPersonasEnTabla();
}

function PeticionDeps() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        let arrayDatosDeps;
        miPeticion.open("GET", "http://localhost:5188/api/departamentos");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    arrayDatosDeps = JSON.parse(miPeticion.responseText);//esto es un array de objetos de api con el nombre accesible con nombreDep
                    //esto crea departamentos con el id y el nombre de mi entidad accesible con nombre, pero para acceder a el nombre del objeto de la api se accede con nombreDep para darselo a nombre
                    listaDeps = arrayDatosDeps.map(departamento => new clsDepartamento(departamento.id, departamento.nombreDep));
                    resolve();
                } else {
                    reject("Error al recoger datos de deps de la api")
                }
            }
        };
        miPeticion.send();
    });
}

function PeticionPersonas() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        let arrayDatosPersonas;
        miPeticion.open("GET", "http://localhost:5188/api/personas");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    arrayDatosPersonas = JSON.parse(miPeticion.responseText);
                    listaPersonas = arrayDatosPersonas.map(persona => new clsPersona(persona.id, persona.nombre, persona.apellidos, persona.telefono, persona.direccion, persona.foto, persona.fechaNac, persona.idDepartamento));
                    resolve();
                } else {
                    reject("Error al recoger datos de personas de la api")
                }
            }
        };
        miPeticion.send();
    });
}

function PeticionModificarPersona(personaModificable) {
    let miPeticion = new XMLHttpRequest();
    miPeticion.open("PUT", "http://localhost:5188/api/personas/" + personaModificable.id);

    miPeticion.setRequestHeader("Content-Type", "application/json");//especifico el tipo de contenido que voy a enviar, necesario porque es un put
    miPeticion.onreadystatechange = function () {
        if (miPeticion.readyState < 4) {
            miP.innerHTML = "Cargando";

        } else if (miPeticion.readyState == 4) {
            miP.innerHTML = "";
            if (miPeticion.status == 200) {
                alert("Datos enviados correctamente");
            } else {
                //alert("Error al enviar datos", miPeticion.status);
            }
        }
    };
    miPeticion.send(JSON.stringify(personaModificable));//altero el envio de peticion para que sea un json de modeloModificable, necesario al ser un put
}

function CargarPersonasEnTabla() {

    misPersonas.innerHTML = "";

    let headerRow = misPersonas.insertRow(0);
    let headers = ["Foto", "Nombre", "Apellidos", "NombreDepartamento", "Put", "Post", "Delete"];

    for (let i = 0; i < headers.length; i++) {//headers
        let headerCell = headerRow.insertCell(i);
        headerCell.textContent = headers[i];
    }

    for (let i = 0; i < listaPersonas.length; i++) {
        let persona = listaPersonas[i];
        let row = misPersonas.insertRow(i + 1); // empiezo insertando por 1 para saltarme headers

        let cellIdOculto = row.insertCell(0);
        cellIdOculto.hidden = true; // oculto la celda
        cellIdOculto.textContent = persona.id; //le doy el id

        let cellFoto = row.insertCell(1);
        let foto = document.createElement("img");
        foto.src = persona.foto;
        foto.width = 100;
        foto.height = 100;
        cellFoto.appendChild(foto);

        let cellNombre = row.insertCell(2);
        cellNombre.textContent = persona.nombre;
        cellNombre.width = 200;
        cellNombre.height = 100;

        let cellApellidos = row.insertCell(3);
        cellApellidos.textContent = persona.apellidos;
        cellApellidos.width = 200;
        cellApellidos.height = 100;

        let nombreDep = DepByPersonaId(persona.idDepartamento)//USO METODO PARA ASINGAR NOMBRE DE DEPARTAMENTO A FILA DE TABLA LISTA PERSONAS

        let cellNombreDep = row.insertCell(4);
        cellNombreDep.textContent = nombreDep;
        cellNombreDep.width = 200;
        cellNombreDep.height = 100;

        let cellModificar = row.insertCell(5);//creo y localizo en variables la celda, el boton y la imagen
        let btnModificar = document.createElement("button");
        let imgBotonPut = document.createElement("img");

        imgBotonPut.src = persona.foto; //edito la imagen del boton a partir de ruta
        imgBotonPut.width = 50;
        imgBotonPut.height = 50;

        btnModificar.appendChild(imgBotonPut);//agrego la imagen al boton
        btnModificar.addEventListener("click", function (event) {

            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;//fila en la que se da el evento

            let celdaIdEvento = misPersonas.rows[filaEvento].cells[0].textContent;//uso fila para encontrar celdaId donde se da el evento y extraigo el id

            CargaPantallaPutPersona(celdaIdEvento);//le paso el id de la persona al metodo
        });
        cellModificar.appendChild(btnModificar);//agrego el boton a la celda

        let cellPost = row.insertCell(6);
        let btnPost = document.createElement("button");
        let imgBotonPost = document.createElement("img");

        imgBotonPost.src = persona.foto;
        imgBotonPost.width = 50;
        imgBotonPost.height = 50;

        btnPost.appendChild(imgBotonPost);
        btnPost.addEventListener("click", function (event) {
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;
            let celdaIdEvento = misPersonas.rows[filaEvento].cells[0].textContent;

            CargaPantallaPostPersona(celdaIdEvento);
        });

        cellPost.appendChild(btnPost);

        let cellDelete = row.insertCell(7);
        let btnDelete = document.createElement("button");
        let imgBotonDelete = document.createElement("img");

        imgBotonDelete.src = persona.foto;
        imgBotonDelete.width = 50;
        imgBotonDelete.height = 50;

        btnDelete.appendChild(imgBotonDelete);
        btnDelete.addEventListener("click", function (event) {
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;
            let celdaIdEvento = misPersonas.rows[filaEvento].cells[0].textContent;

            CargaPantallaDeletePersona(celdaIdEvento);
        });

        cellDelete.appendChild(btnDelete);
    }
}

//DEVUELVE EL NOMBRE DEL DEPARTAMENTO A PARTIR DE IDDEPARTAMENTO DE LA PERSONA, realizando busqueda sobre listaDeps actuales
function DepByPersonaId(idDepartamento) {
    let dep = listaDeps.find(dep => dep.id == idDepartamento);
    return dep.nombre;//AQUI PUEDE DEVOLVER EL DEP COMPLETO DE SER NECESARIO
}

//DEVUELVE LA PERSONA A PARTIR DE ID RECIBIDO, realizando busqueda sobre listaPersonas actuales
function PersonaByPersonaId(id) {
    let per = listaPersonas.find(per => per.id == id);
    return per;
}

//metodo para convertir fecha con hora a fecha sin hora
function FromDateTimeToDate(fechaRecibida) {
    let fechaDate;

    if (typeof fechaRecibida === 'string') {//comprueba si fecha es tipo string
        fechaDate = new Date(fechaRecibida);//si lo es lo convierte a fecha
    } else if (fechaRecibida instanceof Date) {
        // fechaRecibida is already a Date object
        fechaDate = fechaRecibida;
    } else {//si no es string ni fecha lanza error 
        console.error('Invalid fechaRecibida:', fechaRecibida);
    }
    fechaDate = fechaDate.toISOString().split('T')[0];
    return fechaDate;//devuelve fecha en formato yyyy-mm-dd
}

//metodo para convertir fecha sin hora a fecha con hora
function FromDateToDateTime(fechaRecibida) {
    let fechaDateTime;

    if (typeof fechaRecibida === 'string') {//comprueba si fecha es tipo string
        fechaDateTime = new Date(fechaRecibida);  //si lo es lo convierte a fecha
    } else if (fechaRecibida instanceof Date) {
        // fechaRecibida is already a Date object
        fechaDateTime = new Date(fechaRecibida);
    } else {//si no es string ni fecha lanza error 
        console.error('Invalid fechaRecibida:', fechaRecibida);
    }

    fechaDateTime.setHours(0, 0, 0, 0);//devuelve fecha en formato yyyy-mm-ddT00:00:00

    return fechaDateTime;
}

//ESTE METODO RECIBE EL ID DE LA PERSONA A MODIFICAR LA BUSCA EN LA LISTA DE PERSONAS Y CARGA LOS DATOS EN LA PANTALLA DE MODIFICAR (MODALPUT)
function CargaPantallaPutPersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);
    document.getElementById("idPut").value = persona.id;
    document.getElementById("nombrePut").value = persona.nombre;
    document.getElementById("apellidosPut").value = persona.apellidos;
    document.getElementById("telefonoPut").value = persona.telefono;
    document.getElementById("direccionPut").value = persona.direccion;
    document.getElementById("fotoPut").value = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaNac);//paso a formato sin hora
    document.getElementById("fechaNacPut").value = fecha;
    document.getElementById("idDepartamentoPut").value = persona.idDepartamento;

    OpenModalPut();//una vez los datos estan cargados en el modal lo abro
}

//abre el modal de put al pulsar editar
function OpenModalPut() {
    document.getElementById("modalPut").style.display = "block";
}

//cierra el modal de put al pulsar cancelar
function CloseModalPut() {
    document.getElementById("modalPut").style.display = "none";
}

//hace peticion put, peticion lista personas, cierra el modal y recarga la tabla
async function ConfirmChangesPut() {
    //recorrer modal y guardar datos en persona
    let persona = new clsPersona();

    persona.id = document.getElementById("idPut").value;
    persona.nombre = document.getElementById("nombrePut").value;
    persona.apellidos = document.getElementById("apellidosPut").value;
    persona.telefono = document.getElementById("telefonoPut").value;
    persona.direccion = document.getElementById("direccionPut").value;
    persona.foto = document.getElementById("fotoPut").value;

    let fecha = document.getElementById("fechaNacPut").value;

    persona.fechaNac = FromDateToDateTime(fecha); //cargo fecha en formato fecha con hora con ayuda de metodo FromDateToDateTime

    persona.idDepartamento = document.getElementById("idDepartamentoPut").value;

    await PeticionModificarPersona(persona);//hago peticion put y la espero

    await PeticionPersonas();//vuelvo a hacer petición de personas para actualizar listaPersonas con la persona modificada y la espero

    CloseModalPut(); //cierro el modal antes de recargar listado para evitar problemas de visualización (no se si relacionados con asincronia)

    CargarPersonasEnTabla();//recargo listado de personas en tabla
}


function CargaPantallaPostPersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);
    document.getElementById("idPost").value = persona.id;
    document.getElementById("nombrePost").value = persona.nombre;
    document.getElementById("apellidosPost").value = persona.apellidos;
    document.getElementById("telefonoPost").value = persona.telefono;
    document.getElementById("direccionPost").value = persona.direccion;
    document.getElementById("fotoPost").value = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaNac);
    document.getElementById("fechaNacPost").value = fecha;
    document.getElementById("idDepartamentoPost").value = persona.idDepartamento;

    OpenModalPost();
}

function OpenModalPost() {
    document.getElementById("modalPost").style.display = "block";
}

function CloseModalPost() {
    document.getElementById("modalPost").style.display = "none";
}

async function ConfirmChangesPost() {
    let persona = new clsPersona();

    persona.id = document.getElementById("idPost").value;
    persona.nombre = document.getElementById("nombrePost").value;
    persona.apellidos = document.getElementById("apellidosPost").value;
    persona.telefono = document.getElementById("telefonoPost").value;
    persona.direccion = document.getElementById("direccionPost").value;
    persona.foto = document.getElementById("fotoPost").value;

    let fecha = document.getElementById("fechaNacPost").value;
    persona.fechaNac = FromDateToDateTime(fecha);

    persona.idDepartamento = document.getElementById("idDepartamentoPost").value;

    await PeticionPostPersona(persona);

    await PeticionPersonas();

    CloseModalPost();

    CargarPersonasEnTabla();
}

 
function CargaPantallaDeletePersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);
    document.getElementById("idDelete").value = persona.id;
    document.getElementById("nombreDelete").textContent = persona.nombre;
    document.getElementById("apellidosDelete").textContent = persona.apellidos; 
    document.getElementById("telefonoDelete").textContent = persona.telefono;
    document.getElementById("direccionDelete").textContent = persona.direccion;
    document.getElementById("fotoDelete").textContent = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaNac);
    document.getElementById("fechaNacDelete").textContent = fecha;

    document.getElementById("idDepartamentoDelete").textContent = persona.idDepartamento;

    OpenModalDelete();
}

function OpenModalDelete() {
    document.getElementById("modalDelete").style.display = "block";
}

function CloseModalDelete() {
    document.getElementById("modalDelete").style.display = "none";
}

async function ConfirmChangesDelete() {
    let persona = new clsPersona();

    persona.id = document.getElementById("idDelete").value;

    await PeticionDeletePersona(persona);

    await PeticionPersonas();

    CloseModalDelete();

    CargarPersonasEnTabla();
}

class clsPersona {
    constructor(id, nombre, apellidos, telefono, direccion, foto, fechaNac, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNac = fechaNac
        this.idDepartamento = idDepartamento;
    }
}

class clsDepartamento {
    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
    }
}

/*
//put sigue buggeado al refrescarse
//hacer metodo post y metodo delete
//poner foto en las 3 opciones
//poner la tabla bonita
//y nos vamos a los deps
*/