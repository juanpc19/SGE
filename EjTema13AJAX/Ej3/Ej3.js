// JavaScript source code
 
window.onload = InicializaEventos;
var listaDepartamentos;
var listaPersonas;

//indico que es funcion asincrona porque espera a 2 funciones asincronas internas
async function InicializaEventos() {
    //le doy a scritp localizacion de los elementos html
    miDiv = document.getElementById("miDiv");
    miTabla = document.getElementById("miTabla");
    miP = document.getElementById("textoCarga");

    //le digo que espere a las peticiones asincronas que regeran los datos de la api
    await PeticionPersonas();
    await PeticionDepartamentos();
    //y que cuando las tenga cargue los datos tabla
    CargarEnTabla();

}

//funcion para peticion asincrona a api de personas, obtiene el listado
 //1.creo peticion 2.la preparo con open 3.preparo funcion para cuando cambie estado
 //4.la envio con send 5. va cambiando de estado hasta que termina 6. devuelve codigo y datos
 //al estar dentro de promesa el declarar la promesa seria 0. y el resolve y reject 7 y 8 segun devuelva datos o no
function PeticionPersonas() {
    //devuelve una promesa (datos asincronos), puede devolver o no datos (resolve/reject)
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();//creo mi peticion 
        miPeticion.open("GET", "https://crudjuan.azurewebsites.net/api/personas");//le doy el metodo y el endpoint a open para preparar peticion
        miPeticion.onreadystatechange = function () { //cada vez que cambie el esta de la peticion se activa la siguiente funcion
            if (miPeticion.readyState < 4) {//si el estado es menor que 4 es que la peticion no ha terminado 
                miP.innerHTML = "Cargando...";
            } else if (miPeticion.readyState == 4) { // si el estado es 4 es que la peticion ha terminado
                miP.innerHTML = "";
                if (miPeticion.status == 200) {//devuelvo codigo correspondiente a tipo de peticion
                    listaPersonas = JSON.parse(miPeticion.responseText);//y recojo datos en listaPersonas
                    resolve(); // como la promesa se ha cumplido, resuelvo la promesa
                } else {
                    reject("Error al recoger datos de api"); // si no se ha cumplido la promesa, la rechazo
                }
            }
        };
        miPeticion.send();
    });
}

//igual que PeticionPersonas pero con departamentos
function PeticionDepartamentos() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("GET", "https://crudjuan.azurewebsites.net/api/departamentos");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando...";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    listaDepartamentos = JSON.parse(miPeticion.responseText);
                    resolve(); // Resolve the promise when the data is successfully fetched
                } else {
                    reject("Error al recoger datos de api"); // Reject the promise in case of an error
                }
            }
        };
        miPeticion.send();
    });
}


//asigna valores recogidos de api a celdas de tabla
  function CargarEnTabla() {
       
          for (let i=0; i < listaPersonas.length; i++) {//recorro lista de personas
              //preparo fila con sus celdas 
              let miFila = miTabla.insertRow(miTabla.length); //guardo localizacion ultima fila
              let celdaNombre = miFila.insertCell(0); //guardo localizacion donde inserto cada celda
              let celdaApellidos = miFila.insertCell(1);
              let celdaNombreDep = miFila.insertCell(2);
              //preparo persona con sus datos
              let persona = listaPersonas[i];//recojo persona y accedo a sus datos (esto funciona como si ya tuviera la entidad)
              let nombre = persona.nombre;
              let apellidos = persona.apellidos;
              let idDepartamento = persona.idDepartamento;
              //uso idDepartamento de persona para buscar nombre de departamento en metodo en siguiente linea
              let nombreDep = BuscarDepartamento(idDepartamento);
              //y doy valores a las 3 celdas
              celdaNombre.innerHTML = nombre;
              celdaApellidos.innerHTML = apellidos;
              celdaNombreDep.innerHTML = nombreDep;       
      }  
}

//metodo para buscar nombre de departamento con id de departamento
function BuscarDepartamento(idDepartamento) {
    for (let i=0; i < listaDepartamentos.length; i++) {
        let departamento = listaDepartamentos[i];   
        if (departamento.id == idDepartamento) {
            return departamento.nombreDep;
        }
    }
}





 