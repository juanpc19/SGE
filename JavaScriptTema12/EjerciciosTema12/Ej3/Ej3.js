window.onload = InicializaEventos;

//datos a usar 
var listaModelosAudi = ["a1", "a2", "a3"];
var listaModelosSeat = ["s1", "s2", "s3"];
var listaModelosMercedes = ["m1", "m2", "m3"];
var listaMarcas = ["Audi", "Seat", "Mercedes"];
var misMarcas;
var misModelos;

//al cargar la pagina llamo a este evento para que prepare los elementos selects del html
function InicializaEventos() {
    misMarcas = document.getElementById("marcas");//localizo el select de marcas

    misModelos = document.getElementById("modelos");//localizo el select de modelos

    //doy un listener a lista marcas html para que cuando cambie llame a la funcion CargarListadoModelos
    document.getElementById("marcas").addEventListener("change", CargarListadoModelos);

    //recorro el array de listamarcas y voy creando los options del select con sus valores
    for (var i = 0; i < listaMarcas.length; i++) {
        var option = document.createElement("option");//creo un option y lo añado a la lista
        option.value = listaMarcas[i];
        option.text = listaMarcas[i];
        misMarcas.add(option);
    }

    //recorro el array de listamodelosaudi y voy creando los options del select con sus valores 
    //presupongo que el primer select es audi y por eso lo cargo al cargar la pagina
    for (var i = 0; i < listaModelosAudi.length; i++) {
        var option = document.createElement("option"); 
        option.value = listaModelosAudi[i];
        option.text = listaModelosAudi[i];
        misModelos.add(option);
    }
}

function CargarListadoModelos() {

    //extraigo el valor del select de marcas para usarlo en el switch
    var marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;

    //segun la opcion seleccion dada recorro un array de string y doy sus valores al select html vaciandolo antes
    switch (marcaSeleccionada) {
        case "Audi":
            misModelos.innerHTML = "";//para vaciar el select
            for (var i = 0; i < listaModelosAudi.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosAudi[i];
                option.text = listaModelosAudi[i];
                misModelos.add(option);
            }
            break;

        case "Seat":
            misModelos.innerHTML = "";
            for (var i = 0; i < listaModelosSeat.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosSeat[i];
                option.text = listaModelosSeat[i];
                misModelos.add(option);
            }
            break;

        case "Mercedes":
            misModelos.innerHTML = "";
            for (var i = 0; i < listaModelosMercedes.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosMercedes[i];
                option.text = listaModelosMercedes[i];
                misModelos.add(option);
            }
            break;

    }
}



   