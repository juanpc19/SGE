// JavaScript source code
//extrair lista personas y lista deps de api
//meter en fila nombre y apellido de cada persona
//y luego en misma fila meter nombre de dep asociado a persona mediante busquede de id
//todo e un ucle tras recoger datos de api


window.onload = InicializaEventos;
var listaDepartamentos;
var listaPersonas;

function InicializaEventos() {
    miDiv = document.getElementById("miDiv");
    miTabla = document.getElementById("miTabla");
    miP = document.getElementById("textoCarga");
    await PeticionPersonas();
    await PeticionDepartamentos();
    CargarEnTabla();

}
async function PeticionPersonas() {
    let miPeticion = new XMLHttpRequest();
    miPeticion.open("GET", "https://crudjuan.azurewebsites.net/api/personas");
    miPeticion.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            miP.innerHTML = "Cargando...";

        } else if (miPeticion.readyState == 4 && miPeticion.status == 200) {
            listaPersonas = JSON.parse(miLlamada.responseText);          
        }
    };
    miPeticion.send();
}

async function PeticionDepartamentos() {
    let miPeticion = new XMLHttpRequest();
    miPeticion.open("GET", "https://crudjuan.azurewebsites.net/api/departamentos");
    miPeticion.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            miP.innerHTML = "Cargando...";

        } else if (miPeticion.readyState == 4 && miPeticion.status == 200) {
            listaDepartamentos = JSON.parse(miLlamada.responseText);           
        }
    };
    miPeticion.send();
}

function CargarEnTabla() {

    for (let i; i < listaPersonas.length; i++) {
        //preparo fila con sus celdas
        let miFila = miTabla.insertRow(miTabla.length);
        let celdaNombre = row.insertCell(0);
        let celdaApellidos = row.insertCell(1);
        let celdaNombreDep = row.insertCell(2);
        //preparo persona con sus datos
        let persona = listaPersonas[i];
        let nombre = persona.nombre;
        let apellidos = persona.apellidos;
        let idDepartamento = persona.idDepartamento;
        //uso iddepartamento para buscar nombre de departamento en metodo en siguiente linea
        let nombreDepartamento = BuscarDepartamento(idDepartamento);
        //y doy valores a las 3 celdas
        celdaNombre.innerHTML = nombre;
        celdaApellidos.innerHTML = apellidos;
        celdaNombreDep.innerHTML = nombreDepartamento;

    }
}

function BuscarDepartamento(idDepartamento) {
    for (let i; i < listaDepartamentos.length; i++) {
        let departamento = listaDepartamentos[i];
        if (departamento.id == idDepartamento) {
            return departamento.nombre;
        }
    }
}



















function pedirDatos() {

    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", "https://vuestraapipersonas/api/Personas");

    //Definicion estados

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            divMensaje.innerHTML = "Cargando...";

        }

        else

            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                var arrayPersonas = JSON.parse(miLlamada.responseText);

                funcionQueHagaAlgoConLasPersonas(arrayPersonas);

            }

    };

    miLlamada.send();

}
