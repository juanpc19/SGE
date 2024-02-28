
//http://localhost:5188/PaginaCrud.html
//http://localhost:5188/api/departamentos
//http://localhost:5188/api/personas

window.onload = InicializaEventos;

//elementos html
 
var miTabla;
var miP;

//variables globales
var listaDeps;
var listaPersonas;

//hara carga inicial perparando los deps y las personas ademas de localizar algunos elementos html y cargara las personas en la tabla
async function InicializaEventos() {
    miTabla = document.getElementById("miTablaCrud");
    miP = document.getElementById("textoCarga");

    await PeticionDepartamentos();
    await PeticionPersonas();

    CargarPersonasEnTabla();
}

//metodo que hara peticion getAll de departamentos a api y los guardara en variable global
function PeticionDepartamentos() {
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
                    resolve();//devuelvo la resolucion de la promesa
                } else {
                    reject("Error al recoger datos de deps de la api")//devuelvo el rechazo de la promesa
                }
            }
        };
        miPeticion.send();
    });
}

//metodo que hara peticion getAll de personas a api y los guardara en variable global
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

//metodo que hara peticion put de persona a api
function PeticionModificarPersona(personaModificable) {
    return new Promise((resolve, reject) => {

        let miPeticion = new XMLHttpRequest();
        miPeticion.open("PUT", "http://localhost:5188/api/personas/" + personaModificable.id);
        miPeticion.setRequestHeader("Content-Type", "application/json");//especifico el tipo de contenido que voy a enviar, necesario porque es un put
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    alert("Departamento modificada correctamente");
                    resolve();
                } else {
                    alert("Error al modificar departamento", miPeticion.status);
                    reject();
                }
            }
        };
        miPeticion.send(JSON.stringify(personaModificable));//altero el envio de peticion para que sea un json de modeloModificable, necesario al ser un put
    });
}

//metodo que hara peticion put de departamento a api
function PeticionModificarDepartamento(depModificable) {
    return new Promise((resolve, reject) => {

        let miPeticion = new XMLHttpRequest();
        miPeticion.open("PUT", "http://localhost:5188/api/departamentos" + depModificable.id);
        miPeticion.setRequestHeader("Content-Type", "application/json");//especifico el tipo de contenido que voy a enviar, necesario porque es un put
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    alert("Departamento modificado correctamente");
                    resolve();
                } else {
                    alert("Error al modificar departamento", miPeticion.status);
                    reject();
                }
            }
        };
        miPeticion.send(JSON.stringify(depModificable));//altero el envio de peticion para que sea un json de modeloModificable, necesario al ser un put
    });
}

//metodo que hara peticion post de persona a api
function PeticionPostPersona(persona) {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("POST", "http://localhost:5188/api/personas");
        miPeticion.setRequestHeader("Content-Type", "application/json");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 201) {
                    alert("Persona añadida correctamente");
                    resolve();
                } else {
                    alert("Error al añadir persona", miPeticion.status);
                    reject();
                }
            }
        };
        miPeticion.send(JSON.stringify(persona))
    });
}

//metodo que hara peticion post de departamento a api
function PeticionPostDepartamento(departamento) {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("POST", "http://localhost:5188/api/departamentos");
        miPeticion.setRequestHeader("Content-Type", "application/json");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 201) {
                    alert("Departamento añadido correctamente");
                    resolve();
                } else {
                    alert("Error al añadir departamento", miPeticion.status);
                    reject();
                }
            }
        };
        miPeticion.send(JSON.stringify(departamento))
    });
}

//metodo que hara peticion delete de persona a api
function PeticionDeletePersona(idPersonaBorrar) {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("DELETE", "http://localhost:5188/api/personas/" + idPersonaBorrar);
        miPeticion.setRequestHeader("Content-Type", "application/json");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    alert("Persona borrada correctamente");
                    resolve();
                } else {
                    alert("Error al borrar persona");
                    reject();
                }
            }
        };
        miPeticion.send();
    });
}

//metodo que hara peticion delete de departamento a api
function PeticionDeleteDepartamento(idDepartamentoBorrar) {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("DELETE", "http://localhost:5188/api/departamentos/" + idDepartamentoBorrar);
        miPeticion.setRequestHeader("Content-Type", "application/json");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    alert("Departamento borrado correctamente");
                    resolve();
                } else {
                    alert("Error al borrar departamento");
                    reject();
                }
            }
        };
        miPeticion.send();
    });
}

//cargara o recargara personas en tabla a partir de listaPersonas ademas cambia el metodo llamado en click de boton agregar a agregar persona
function CargarPersonasEnTabla() {

    miTabla.innerHTML = "";//vacio la tabla para poder usar la funcion para recargar

    //miTabla.style.width = '90%';//doy ancho a tabla con porcentaje para adaptar a la carga de las personas (mas tds)

    CambiaAgregarPersona();//cambio el modal al que el boton agregar llama en evento para reutilizar el boton

    let headerRow = miTabla.insertRow(0);//inserto fila
    let headers = ["Foto", "Nombre", "Apellidos", "NombreDepartamento", "Editar", "Eliminar"];

    for (let i = 0; i < headers.length; i++) {//recorro fila poniendo los headers
        let headerCell = headerRow.insertCell(i);
        headerCell.textContent = headers[i];
        headerCell.classList.add("headers");//creo estilo css con js, asi puedo asignar a esta celda un estilo desde el css automaticamente
    }

    for (let i = 0; i < listaPersonas.length; i++) {
        let persona = listaPersonas[i];
        let row = miTabla.insertRow(i + 1); // empiezo insertando por i+1 para saltarme headers

        let cellIdOculto = row.insertCell(0);
        cellIdOculto.hidden = true; // oculto la celda id
        cellIdOculto.textContent = persona.id; //le doy el id

        let cellFoto = row.insertCell(1);//guardo referencia de celda en variable para modificacion posterior
        cellFoto.classList.add("td-foto");  
        let foto = document.createElement("img");
        foto.classList.add("foto");
        foto.src = persona.foto; 
        cellFoto.appendChild(foto);//le agrego la foto a la celda

        let cellNombre = row.insertCell(2);
        cellNombre.classList.add("td-nombre");
        cellNombre.textContent = persona.nombre; 

        let cellApellidos = row.insertCell(3);
        cellApellidos.classList.add("td-apellidos");
        cellApellidos.textContent = persona.apellidos; 

        let nombreDep = DepByPersonaId(persona.idDepartamento)//USO METODO PARA ASINGAR NOMBRE DE DEPARTAMENTO A FILA DE TABLA LISTA PERSONAS

        let cellNombreDep = row.insertCell(4);
        cellNombreDep.classList.add("td-nombreDep");
        cellNombreDep.textContent = nombreDep; 

        let cellModificar = row.insertCell(5);//creo y localizo en variables la celda, el boton y la imagen
        cellModificar.classList.add("td-accion");
        let btnModificar = document.createElement("button");
        btnModificar.classList.add("td-accion-button");
        let imgBotonPut = document.createElement("img");
        imgBotonPut.classList.add("td-accion-button-img");

        imgBotonPut.src = "Resources/Imagenes/modificar_persona.png"; //edito la imagen del boton a partir de ruta 

        btnModificar.appendChild(imgBotonPut);//agrego la imagen al boton
        btnModificar.addEventListener("click", function (event) {//agrego evento al boton
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;//fila en la que se da el evento
            let celdaIdEvento = miTabla.rows[filaEvento].cells[0].textContent;//uso fila para encontrar celdaId donde se da el evento y extraigo el id
            CargaPantallaPutPersona(celdaIdEvento);//le paso el id de la persona al metodo
        });
        cellModificar.appendChild(btnModificar);//agrego el boton a la celda

        let cellDelete = row.insertCell(6);
        cellDelete.classList.add("td-accion");
        let btnDelete = document.createElement("button");
        btnDelete.classList.add("td-accion-button");
        let imgBotonDelete = document.createElement("img");
        imgBotonDelete.classList.add("td-accion-button-img");

        imgBotonDelete.src = "Resources/Imagenes/borrar_persona.png"; 

        btnDelete.appendChild(imgBotonDelete);
        btnDelete.addEventListener("click", function (event) {
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;
            let celdaIdEvento = miTabla.rows[filaEvento].cells[0].textContent;

            CargaPantallaDeletePersona(celdaIdEvento);
        });
        cellDelete.appendChild(btnDelete);
    }
}

//cargara o recargara departamentos en tabla a partir de listaDepartamentos ademas cambia el metodo llamado en click de boton agregar a agregar dep
function CargarDepartamentosEnTabla() {

    miTabla.innerHTML = "";//vacio la tabla para poder usar la funcion para recargar

    //miTabla.style.width = '50%';//doy ancho a tabla con porcentaje para adaptar a la carga de los departamentos (menos tds)

    CambiaAgregarDep();//cambio el modal al que el boton agregar llama en evento para reutilizar el boton

    let headerRow = miTabla.insertRow(0);
    let headers = ["NombreDepartamento", "Editar", "Eliminar"];

    for (let i = 0; i < headers.length; i++) {//headers
        let headerCell = headerRow.insertCell(i);
        headerCell.textContent = headers[i];
        headerCell.classList.add("headers");
    }

    for (let i = 0; i < listaDeps.length; i++) {
        let departamento = listaDeps[i];
        let row = miTabla.insertRow(i + 1); // empiezo insertando por i+1 para saltarme headers

        let cellIdOculto = row.insertCell(0);
        cellIdOculto.hidden = true; // oculto la celda id
        cellIdOculto.textContent = departamento.id; //le doy el id

        let cellNombreDep = row.insertCell(1);
        cellNombreDep.textContent = departamento.nombreDep;
        cellNombreDep.classList.add("td-nombreDep");

        let cellModificar = row.insertCell(2);//creo y localizo en variables la celda, el boton y la imagen
        cellModificar.classList.add("td-accion");
        let btnModificar = document.createElement("button");
        btnModificar.classList.add("td-accion-button");
        let imgBotonPut = document.createElement("img");
        imgBotonPut.classList.add("td-accion-button-img");

        imgBotonPut.src = "Resources/Imagenes/modificar_persona.png"; //edito la imagen del boton a partir de ruta

        btnModificar.appendChild(imgBotonPut);//agrego la imagen al boton
        btnModificar.addEventListener("click", function (event) {//agrego evento al boton
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;//fila en la que se da el evento
            let celdaIdEvento = miTabla.rows[filaEvento].cells[0].textContent;//uso fila para encontrar celdaId donde se da el evento y extraigo el id
            CargaPantallaPutDep(celdaIdEvento);//le paso el id del dep al metodo
        });
        cellModificar.appendChild(btnModificar);//agrego el boton a la celda

        let cellDelete = row.insertCell(3);
        cellDelete.classList.add("td-accion");
        let btnDelete = document.createElement("button");
        btnDelete.classList.add("td-accion-button");
        let imgBotonDelete = document.createElement("img");
        imgBotonDelete.classList.add("td-accion-button-img");

        imgBotonDelete.src = "Resources/Imagenes/borrar_persona.png";

        btnDelete.appendChild(imgBotonDelete);
        btnDelete.addEventListener("click", function (event) {
            let filaEvento = event.currentTarget.parentElement.parentElement.rowIndex;
            let celdaIdEvento = miTabla.rows[filaEvento].cells[0].textContent;

            CargaPantallaDeleteDep(celdaIdEvento);
        });
        cellDelete.appendChild(btnDelete);
    }
}

//DEVUELVE EL NOMBRE DEL DEPARTAMENTO A PARTIR DE IDDEPARTAMENTO DE LA PERSONA, realizando busqueda sobre listaDeps actuales
function DepByPersonaId(idDepartamento) {
    let dep = listaDeps.find(dep => dep.id == idDepartamento);
    return dep.nombreDep;//AQUI PUEDE DEVOLVER EL DEP COMPLETO DE SER NECESARIO
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

//cambia evento click de boton flotante agregar y su imagen a persona
function CambiaAgregarPersona() {
    let botonAgregar = document.getElementById("botonAgregar");
    botonAgregar.onclick = function () {
        OpenModalPost();
    };
}

//cambia evento click de boton flotante agregar y su imagen a dep
function CambiaAgregarDep() {
    let botonAgregar = document.getElementById("botonAgregar");
    botonAgregar.onclick = function () {
        OpenModalPostDep();//por implementar
    };
}

//ESTE METODO RECIBE EL ID DE LA PERSONA A MODIFICAR LA BUSCA EN LA LISTA DE PERSONAS Y CARGA LOS DATOS EN LA PANTALLA DE MODIFICAR (MODALPUT)
function CargaPantallaPutPersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);//encuentro persona

    document.getElementById("idPut").value = persona.id;//cargo sus datos
    document.getElementById("nombrePut").value = persona.nombre;
    document.getElementById("apellidosPut").value = persona.apellidos;
    document.getElementById("telefonoPut").value = persona.telefono;
    document.getElementById("direccionPut").value = persona.direccion;
    document.getElementById("fotoPut").value = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaNac);//paso a formato sin hora
    document.getElementById("fechaNacPut").value = fecha;
    document.getElementById("idDepartamentoPut").value = persona.idDepartamento;
    document.getElementById("imagenPut").src = persona.foto

    OpenModalPut();//una vez los datos estan cargados en el modal lo abro
}

//abre el modal de put al pulsar boton editar
function OpenModalPut() {
    document.getElementById("modalPut").style.display = "block";
}

//cierra el modal de put al pulsar cancelar
function CloseModalPut() {
    document.getElementById("modalPut").style.display = "none";
}

//hace peticion put, peticion lista personas, cierra el modal y recarga la tabla
async function ConfirmPut() {
    let persona = new clsPersona();//instancio persona

    persona.id = document.getElementById("idPut").value;// le doy valores exatraidos de modal
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

    CloseModalPut(); //cierro el modal antes de recargar listado

    CargarPersonasEnTabla();//recargo listado de personas en tabla
}
 
//abre el modal de post al hacer click en agregar
function OpenModalPost() {
    document.getElementById("modalPost").style.display = "block";
}

//cierra el modal de post vaciandolo para siguiente post 
function CloseModalPost() {
    document.getElementById("nombrePost").value = "";//borro los datos
    document.getElementById("apellidosPost").value = "";
    document.getElementById("telefonoPost").value = "";
    document.getElementById("direccionPost").value = "";
    document.getElementById("fotoPost").value = "";
    document.getElementById("fechaNacPost").value = "";
    document.getElementById("idDepartamentoPost").value = "";

    document.getElementById("modalPost").style.display = "none";//cierro el modal
}

//hace peticion post, peticion lista personas, cierra el modal y recarga la tabla
async function ConfirmPost() {
    let persona = new clsPersona();//instancio persona

    persona.nombre = document.getElementById("nombrePost").value;//le doy valores
    persona.apellidos = document.getElementById("apellidosPost").value;
    persona.telefono = document.getElementById("telefonoPost").value;
    persona.direccion = document.getElementById("direccionPost").value;
    persona.foto = document.getElementById("fotoPost").value;
    let fecha = document.getElementById("fechaNacPost").value;
    persona.fechaNac = FromDateToDateTime(fecha);
    persona.idDepartamento = document.getElementById("idDepartamentoPost").value;

    await PeticionPostPersona(persona);//se la paso al post y espero a peticion

    await PeticionPersonas();//recogo datos de personas con nueva persona y espero a peticion

    CloseModalPost();//cierro el modal

    CargarPersonasEnTabla();//recargo la lista personas en la tabla 
}

//ESTE METODO RECIBE EL ID DE LA PERSONA A BORRAR LA BUSCA EN LA LISTA DE PERSONAS Y CARGA LOS DATOS EN LA PANTALLA DE BORRAR (MODALDELETE)
function CargaPantallaDeletePersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);//encuentro a persona por id con metodo
    document.getElementById("idDelete").value = persona.id;//cargo datos 
    document.getElementById("nombreDelete").textContent = persona.nombre;
    document.getElementById("apellidosDelete").textContent = persona.apellidos;
    document.getElementById("telefonoDelete").textContent = persona.telefono;
    document.getElementById("direccionDelete").textContent = persona.direccion;
    document.getElementById("fotoDelete").textContent = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaNac);
    document.getElementById("fechaNacDelete").textContent = fecha;
    document.getElementById("idDepartamentoDelete").textContent = persona.idDepartamento;
    document.getElementById("imagenDelete").src = persona.foto

    OpenModalDelete();//abro el modal 
}

//abre el modal de delete al pulsar el boton delete
function OpenModalDelete() {
    document.getElementById("modalDelete").style.display = "block";
}

//cierra el modal de delete al pulsar cancelar
function CloseModalDelete() {
    document.getElementById("modalDelete").style.display = "none";
}

//hace peticion delete, peticion lista personas, cierra el modal y recarga la tabla

async function ConfirmDelete() {

    let idPersonaBorrar = document.getElementById("idDelete").value;//extraido el id a partir del campo id en modal

    await PeticionDeletePersona(idPersonaBorrar);//se lo paso al metodo deletePersona y espero a peticion

    await PeticionPersonas();//vuelvo a llamar a listado personas para cargar nueva lista sin persona borrada y espero a peticion

    CloseModalDelete();//cierro el modal 

    CargarPersonasEnTabla(); // vuelvo a cargar la lista en la tabla
}

//ESTE METODO RECIBE EL ID DEl dep A MODIFICAR Lo BUSCA EN LA LISTA DE DEPS Y CARGA LOS DATOS EN LA PANTALLA DE modificar (MODALputDEP)
function CargaPantallaPutDep(idDep) {
    let departamento = listaDeps.find(dep => dep.id == idDep);//encuentro persona

    document.getElementById("idPutDep").value = departamento.id;//cargo sus datos
    document.getElementById("nombrePutDep").value = departamento.nombreDep;
 
    OpenModalPutDep();//una vez los datos estan cargados en el modal lo abro
}

//abre el modal de putdep al pulsar boton editar
function OpenModalPutDep() {
    document.getElementById("modalPutDep").style.display = "block";
}

//cierra el modal de putdep al pulsar cancelar
function CloseModalPutDep() {
    document.getElementById("modalPutDep").style.display = "none";
}

//hace peticion put, peticion lista deps, cierra el modal y recarga la tabla
async function ConfirmPutDep() {
    let departamento = new clsDepartamento();//instancio persona

    departamento.id = document.getElementById("idPutDep").value;// le doy valores exatraidos de modal
    departamento.nombreDep = document.getElementById("nombrePutDep").value;
 

    await PeticionModificarDepartamento(departamento);//hago peticion put y la espero

    await PeticionDepartamentos();//vuelvo a hacer petición de personas para actualizar listaPersonas con la persona modificada y la espero

    CloseModalPutDep(); //cierro el modal antes de recargar listado

    CargarDepartamentosEnTabla();//recargo listado de personas en tabla
}

//abre el modal de post al pulsar boton agregar
function OpenModalPostDep() {
    document.getElementById("modalPostDep").style.display = "block";
}

//cierra el modal de post al pulsar cancelar
function CloseModalPostDep() {
    document.getElementById("modalPostDep").style.display = "none";
}

//hace peticion post, peticion lista deps, cierra el modal y recarga la tabla
async function ConfirmPostDep() {
    let departamento = new clsDepartamento();//instancio persona

    departamento.nombreDep = document.getElementById("nombrePostDep").value;


    await PeticionPostDepartamento(departamento);//hago peticion put y la espero

    await PeticionDepartamentos();//vuelvo a hacer petición de personas para actualizar listaPersonas con la persona modificada y la espero

    CloseModalPostDep(); //cierro el modal antes de recargar listado

    CargarDepartamentosEnTabla();//recargo listado de personas en tabla
}

//ESTE METODO RECIBE EL ID DEl dep A BORRAR Lo BUSCA EN LA LISTA DE DEPS Y CARGA LOS DATOS EN LA PANTALLA DE BORRAR (MODALDELETEDEP)
function CargaPantallaDeleteDep(idDep) {
    let departamento = listaDeps.find(dep => dep.id == idDep);
    document.getElementById("idDeleteDep").value = departamento.id;
    document.getElementById("nombreDeleteDep").textContent = departamento.nombreDep;

    OpenModalDeleteDep();//una vez los datos estan cargados en el modal lo abro
}

//abre el modal de deletedep al pulsar boton borrar
function OpenModalDeleteDep() {
    document.getElementById("modalDeleteDep").style.display = "block";
}

//cierra el modal de deletedep al pulsar cancelar
function CloseModalDeleteDep() {
    document.getElementById("modalDeleteDep").style.display = "none";
}

//hace peticion delete, peticion lista personas, cierra el modal y recarga la tabla
async function ConfirmDeleteDep() {
     
  
    let idDepartamentoBorrar = document.getElementById("idDeleteDep").value;

    await PeticionDeleteDepartamento(idDepartamentoBorrar);//hago peticion put y la espero

    await PeticionDepartamentos();//vuelvo a hacer petición de personas para actualizar listaPersonas con la persona modificada y la espero

    CloseModalDeleteDep(); //cierro el modal antes de recargar listado

    CargarDepartamentosEnTabla();//recargo listado de personas en tabla
}


//clase persona
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

//clase departamento
class clsDepartamento {
    constructor(id, nombreDep) {
        this.id = id;
        this.nombreDep = nombreDep;
    }
}


