
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
                alert("Error al enviar datos", miPeticion.status);
            }
        }
    };
    miPeticion.send(JSON.stringify(personaModificable));//altero el envio de peticion para que sea un json de modeloModificable, necesario al ser un put
}

function CargarPersonasEnTabla() {

    let headerRow = misPersonas.insertRow(0);
    let headers = ["Foto", "Nombre", "Apellidos", "NombreDepartamento", "", "", ""];

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
        foto.width = 200; 
        foto.height = 200; 
        cellFoto.appendChild(foto);

        let cellNombre = row.insertCell(2);
        cellNombre.textContent = persona.nombre;
        cellNombre.width = 200;
        cellNombre.height = 200;

        let cellApellidos = row.insertCell(3);
        cellApellidos.textContent = persona.apellidos;
        cellApellidos.width = 200;
        cellApellidos.height = 200;

        let nombreDep = DepByPersonasId(persona.idDepartamento)//USO METODO PARA ASINGAR NOMBRE DE DEPARTAMENTO A FILA DE TABLA LISTA PERSONAS

        let cellNombreDep = row.insertCell(4);
        cellNombreDep.textContent = nombreDep;
        cellNombreDep.width = 200;
        cellNombreDep.height = 200;

        let cellModificar = row.insertCell(5);//creo y localizo en variables la celda, el boton y la imagen
        let btnModificar = document.createElement("button");
        let imgBotonPut = document.createElement("img");

        imgBotonPut.src = persona.foto; //edito la imagen del boton a partir de ruta
        imgBotonPut.width = 50;
        imgBotonPut.height = 50;
        
        btnModificar.appendChild(imgBotonPut);//agrego la imagen al boton
        btnModificar.addEventListener("click", function (event) {
            
            let rowIndex = event.currentTarget.parentElement.parentElement.rowIndex;//fila en la que se da el evento
            
            let firstCellContent = misPersonas.rows[rowIndex].cells[0].textContent;//uso fila para encontrar celda donde se da el evento
      
            CargaPantallaModificarPersona(firstCellContent);//le paso el id de la persona al metodo
        });
        cellModificar.appendChild(btnModificar);//agrego el boton a la celda
    }
}

//DEVUELVE EL NOMBRE DEL DEPARTAMENTO A PARTIR DE IDDEPARTAMENTO DE LA PERSONA
function DepByPersonasId(idDepartamento) {
    let dep = listaDeps.find(dep => dep.id == idDepartamento);
    return dep.nombre;//AQUI PUEDE DEVOLVER EL DEP COMPLETO DE SER NECESARIO
}

//ESTE METODO RECIBE EL ID DE LA PERSONA A MODIFICAR LA BUSCA EN LA LISTA DE PERSONAS Y CARGA LOS DATOS EN LA PANTALLA DE MODIFICAR (MODAL)
function CargaPantallaModificarPersona(idPersona) {
    let persona = listaPersonas.find(per => per.id == idPersona);
    document.getElementById("nombre").value = persona.nombre;
    document.getElementById("apellidos").value = persona.apellidos;
    document.getElementById("telefono").value = persona.telefono;
    document.getElementById("direccion").value = persona.direccion;
    document.getElementById("foto").value = persona.foto;
    let fecha = FromDateTimeToDate(persona.fechaFec);
    document.getElementById("fechaFec").value = fecha;//pasar a formato sin tiempo
    document.getElementById("idDepartamento").value = persona.idDepartamento;


    OpenModal();//deberia pasar datos de persona al modal antes de open
}

///abre el modal en pulsar editar
function OpenModal() {
    document.getElementById("myModal").style.display = "block";
    // Populate the form with persona data if needed
}

//cierra el modal en cancelar
function CloseModal() {
    document.getElementById("myModal").style.display = "none";
    // Clear the form if needed
}
//hace peticion put y cierra el modal
function ConfirmChanges() {
    PeticionModificarPersona(persona);
    CloseModal(); // Close the modal after confirming changes
}

function FromDateTimeToDate(fechaRecibida) {


    return fechaRecibida.toISOString().split('T')[0];//esto js lo siguiente es c#

          // Given DateTime
       // DateTime fechaRecibida = DateTime.Now;

        // Convert DateTime to Date
        //DateTime dateOnly = fechaRecibida.Date;

}
function FromDateToDateTime(fechaRecibida) {

        // Convert Date back to DateTime
       // DateTime convertedDateTime = dateOnly.Add(fechaRecibida.TimeOfDay);

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

