 

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

//por cromprobar
function PeticionModificarModelo(modeloModificable) {
    let miPeticion = new XMLHttpRequest();
    miPeticion.open("PUT", "http://localhost:5116/api/modelos/" + modeloModificable.id);

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
    miPeticion.send(JSON.stringify(modeloModificable));//altero el envio de peticion para que sea un json de modeloModificable, necesario al ser un put
}

function CargarListadoModelos() {

    let marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;//recojo marca seleccionada (id guardado en el .value) en select por user
    let oMarca = listaMarcas.find(x => x.id == marcaSeleccionada);//la uso para encontrar la cls marca con ese id
    
    listaModelosPorMarca = listaModelos.filter(x => x.idMarca == oMarca.id);//filtro los modelos por la marca seleccionada
    misModelos.innerHTML = "";//vacio la tabla para rellenarla con los nuevos datos

    let filaEncabezado = misModelos.insertRow(0); //cojo referencia fila de encabezado

    let thModelo = document.createElement("th");//creo th  le doy valor y lo añado a la fila
    thModelo.innerHTML = "Modelo";
    filaEncabezado.appendChild(thModelo);

    let thPrecio = document.createElement("th");
    thPrecio.innerHTML = "Precio";
    filaEncabezado.appendChild(thPrecio);
    
    //recorro listaModelosPorMarca en inserto sus valores en la tabla mientras la voy creando
    for (let i = 0; i < listaModelosPorMarca.length; i++) {

        let fila = misModelos.insertRow(i+1);//cojo referencia de fila a partir de referencia a tabla (misModelos)

        let celdaNombre = fila.insertCell(0);
        let celdaPrecio = fila.insertCell(1);
        
        let inputPrecio = document.createElement("input");//creo input le especificao tipo y lo añado a la celda
        inputPrecio.type = "text";
        celdaPrecio.appendChild(inputPrecio);

        celdaNombre.innerHTML = listaModelosPorMarca[i].nombre;//doy valores a celdas
        inputPrecio.value = listaModelosPorMarca[i].precio;    
    }
}

  async function EnviarNuevosPrecios() {

      const peticiones = [];//guardaré las peticiones en un array para esperar a que todas se resuelvan sin bloquear el for

    //empiezo en 1 para saltar la fila de encabezado que puede dar null
      for (let i = 1; i < misModelos.rows.length; i++) {
          let filaActual = misModelos.rows[i];
          //extraigo precio a partir de filaActual/celda/input el query selector permite extraer el valor de un input, util de haber dos valores dentro de un td
          let nuevoPrecioInput = filaActual.cells[1].querySelector("input");
 
              let nuevoPrecio = nuevoPrecioInput.value;//guardo el valor del input.value en varible nuevoPrecio

          if (listaModelosPorMarca[i - 1].precio != nuevoPrecio) {//uso -1 para que coincida con el indice de listaModelosPorMarca
              let modelo = new clsModelo(listaModelosPorMarca[i - 1].id, listaModelosPorMarca[i - 1].idMarca, listaModelosPorMarca[i - 1].nombre, nuevoPrecio);
              peticiones.push(PeticionModificarModelo(modelo)); //añado la peticion a un array de peticiones
                  //await PeticionModificarModelo(modelo);
              }
      }

      await Promise.all(peticiones);//espero a que todas las peticiones se resuelvan

      //recargo la lista de modelos para que se actualicen los precios
      await PeticionModelos();
      //recargo el listado de modelos en la tabla
      CargarListadoModelos();
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





 