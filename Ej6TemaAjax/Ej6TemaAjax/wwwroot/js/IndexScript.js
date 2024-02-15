 

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
//variables globales
var listaMarcas;
var listaModelos;
var listaModelosPorMarca;

async function InicializaEventos() {
    misMarcas = document.getElementById("marcas");
    misModelos = document.getElementById("modelos");
    miP = document.getElementById("textoCarga");
    misMarcas.addEventListener("change", CargarListadoModelos);
    //crear boton y darle listener
    await PeticionMarcas();
    await PeticionModelos();

    //recorro el array de listamarcas y voy creando los options del select con sus valores
    for (var i = 0; i < listaMarcas.length; i++) {
        var option = document.createElement("option", false);//creo un option y lo añado a la lista
        option.value = listaMarcas[i].id;
        option.text = listaMarcas[i].nombre;
         
        misMarcas.add(option);
    }

    //option.defaultSelected = false;
  
}

//cargar listado modelos se encarga  de cargar listado modelos por marca segun mar selec  evaluado en switch,
//una vez tengo los listados los meto en elementos html edsde inicializa eventos,
//cargarlistados es asyncrono
//si peticion listado correcta cargo enlista marcas y en caso modelos filtro por id y cargo en lista modelos
//hacer esta vaina en local

function PeticionMarcas() {
    return new Promise((resolve, reject) => {
        let miPeticion = new XMLHttpRequest();
        miPeticion.open("GET", "http://localhost:5116/api/marcas");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    listaMarcas = JSON.parse(miPeticion.responseText);
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
        miPeticion.open("GET", "http://localhost:5116/api/modelos");
        miPeticion.onreadystatechange = function () {
            if (miPeticion.readyState < 4) {
                miP.innerHTML = "Cargando";
            } else if (miPeticion.readyState == 4) {
                miP.innerHTML = "";
                if (miPeticion.status == 200) {
                    listaModelos = JSON.parse(miPeticion.responseText);
                    listaModelos = modelosData.map(modelo => new clsModelo(modelo.id, modelo.idMarca, modelo.nombre, modelo.precio));
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

    var marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;
    marcaSeleccionada.id;
    listaModelosPorMarca = listaModelos.filter(x => x.idMarca == marcaSeleccionada.label);

    //misModelos.clear();

    for (var i = 0; i < listaModelosPorMarca.length; i++) {

        var option = document.createElement("option");
        option.text = listaModelosPorMarca[i].nombre;
        misModelos.add(option);


    }

    //for (var i = 0; i < listaModelos.length; i++) {
    //    var option = document.createElement("option");
         
    //    option.text = listaModelosPorMarca[i];
    //    listaModelosPorMarca.add(option);
    //}

}




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



 



//EJ DE PICKERS RE MARCAS Y MODELOS
//function CargarListadoModelos() {

//    //extraigo el valor del select de marcas para usarlo en el switch
//    var marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;

//    //segun la opcion seleccion dada recorro un array de string y doy sus valores al select html vaciandolo antes
//    switch (marcaSeleccionada) {
//        case "Audi":
//            misModelos.innerHTML = "";//para vaciar el select
//            for (var i = 0; i < listaModelosAudi.length; i++) {
//                var option = document.createElement("option");
//                option.value = listaModelosAudi[i];
//                option.text = listaModelosAudi[i];
//                misModelos.add(option);
//            }
//            break;

//        case "Seat":
//            misModelos.innerHTML = "";
//            for (var i = 0; i < listaModelosSeat.length; i++) {
//                var option = document.createElement("option");
//                option.value = listaModelosSeat[i];
//                option.text = listaModelosSeat[i];
//                misModelos.add(option);
//            }
//            break;

//        case "Mercedes":
//            misModelos.innerHTML = "";
//            for (var i = 0; i < listaModelosMercedes.length; i++) {
//                var option = document.createElement("option");
//                option.value = listaModelosMercedes[i];
//                option.text = listaModelosMercedes[i];
//                misModelos.add(option);
//            }
//            break;

//    }
//}