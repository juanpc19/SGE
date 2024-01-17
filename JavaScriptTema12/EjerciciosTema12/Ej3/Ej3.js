window.onload = inicializaEventos;

//datos a usar 
var listaModelosAudi = ["a1", "a2", "a3"];
var listaModelosSeat = ["s1", "s2", "s3"];
var listaModelosMercedes = ["m1", "m2", "m3"];
var listaMarcas = ["Audi", "Seat", "Mercedes"];

//al cargar la pagina llamo a este evento para que prepare los elementos selects del html
function inicializaEventos() {
    var misMarcas = document.getElementById("marcas");//localizo el select de marcas

    var misModelos = document.getElementById("modelos");//localizo el select de modelos

    document.getElementById("modelos").addEventListener("change", CargarListadoModelos)//asigno evento de funcion al select

    //recorro el array de listamarcas y voy creando los options del select con sus valores
    for (var i = 0; i < listaMarcas.length; i++) {
        var option = document.createElement("option");//creo un option y lo añado a la lista
        option.value = listaMarcas[i];
        option.text = listaMarcas[i];
        misMarcas.add(option);
    }
}

function CargarListadoModelos() {

    var marcaSeleccionada = misMarcas.options[misMarcas.selectedIndex].value;

    switch (marcaSeleccionada) {
        case "Audi":
            VaciarListadoModelos();
            for (var i = 0; i < listaModelosAudi.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosAudi[i];
                option.text = listaModelosAudi[i];
                misModelos.add(option);
            }
            break;

        case "Seat":
            VaciarListadoModelos();
            for (var i = 0; i < listaModelosSeat.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosSeat[i];
                option.text = listaModelosSeat[i];
                misModelos.add(option);
            }
            break;

        case "Mercedes":
            VaciarListadoModelos();
            for (var i = 0; i < listaModelosMercedes.length; i++) {
                var option = document.createElement("option");
                option.value = listaModelosMercedes[i];
                option.text = listaModelosMercedes[i];
                misModelos.add(option);
            }
            break;
    }
}

function VaciarListadoModelos() {
    for (var i = 0; i < misModelos.length; i++) {
        
        misModelos[i].remove();
    }
}


   