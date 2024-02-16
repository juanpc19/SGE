 

window.onload = InicializaEventos;

//http://localhost:5116/Index.html
//http://localhost:5116/api/marcas
//http://localhost:5116/api/modelos

//https://ej6temaajaxjuan.azurewebsites.net/Index.html
//https://ej6temaajaxjuan.azurewebsites.net/api/marcas
//https://ej6temaajaxjuan.azurewebsites.net/api/modelos


//elementos html
var misMarcas;
var misModelos;
var miP;
var inputText;
//variables globales
var listaMarcas;
var listaModelos;
var listaModelosPorMarca;

async function InicializaEventos() {
    misMarcas = document.getElementById("marcas");
    misModelos = document.getElementById("modelos");
    miP = document.getElementById("textoCarga");
    miBoton = document.getElementById("btn");
    misMarcas.addEventListener("change", CargarListadoModelos);
    miBoton.addEventListener("click", EnviarNuevosPrecios);

    //crear boton y darle listener
    await PeticionMarcas();
    await PeticionModelos();

    //recorro el array de listamarcas y voy creando los options del select con sus valores
    for (let i = 0; i < listaMarcas.length; i++) {
        let option = document.createElement("option", false);//creo un option y lo añado a la lista
        option.value = listaMarcas[i].id;
        option.text = listaMarcas[i].nombre;
        misMarcas.add(option);
    }

    //option.defaultSelected = false;
  
}

//revisar ths in hacer put de precio recorriendo tabla 

function PeticionMarcas() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        let arrayDatosMarcas;
        miPeticion.open("GET", "http://localhost:5116/api/marcas");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    arrayDatosMarcas = JSON.parse(miPeticion.responseText);
                    listaMarcas = arrayDatosMarcas.map(marca => new clsMarca(marca.id, marca.nombre));
                    resolve();
                } else {
                    reject("Error al recoger datos de marcas de la api")
                }
            }
        };
        miPeticion.send();
    });
}

function PeticionModelos() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        let arrayDatosModelos;
        miPeticion.open("GET", "http://localhost:5116/api/modelos");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    arrayDatosModelos = JSON.parse(miPeticion.responseText);
                    listaModelos = arrayDatosModelos.map(modelo => new clsModelo(modelo.id, modelo.idMarca, modelo.nombre, modelo.precio));
                    resolve();
                } else {
                    reject("Error al recoger datos de marcas de la api")
                }
            }
        };
        miPeticion.send();
    });
}

function CargarListadoModelos() {

    let marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;//recojo marca seleccionada (id guardado en el .value) en select por user
    let oMarca = listaMarcas.find(x => x.id == marcaSeleccionada);//la uso para encontrar la cls marca con ese id
    
    listaModelosPorMarca = listaModelos.filter(x => x.idMarca == oMarca.id);
    misModelos.innerHTML = "";
     
    for (let i = 0; i < listaModelosPorMarca.length; i++) {
        let fila = misModelos.insertRow(misModelos.length);
        let celdaNombre = fila.insertCell(0);
        let celdaPrecio = fila.insertCell(1);
        
        let inputPrecio = document.createElement("input");
        inputPrecio.type = "text";
        celdaPrecio.appendChild(inputPrecio);

        celdaNombre.innerHTML = listaModelosPorMarca[i].nombre;
        inputPrecio.value = listaModelosPorMarca[i].precio;    
    }
}

function EnviarNuevosPrecios() {

}

//for (let i = 0; i < listaModelosPorMarca.length; i++) {

//    let option = document.createElement("option");
//    option.value = listaModelosPorMarca[i].id;
//    option.text = listaModelosPorMarca[i].nombre;
//    inputText.placeholder = listaModelosPorMarca[i].precio;
//    misModelos.add(option);
//}

class clsModelo {
    constructor(id, idMarca, nombre, precio) {
        this.id = id;
        this.idMarca = idMarca;
        this.nombre = nombre;
        this.precio = precio;
    }
}

class clsMarca {
    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
    }
}



 


 