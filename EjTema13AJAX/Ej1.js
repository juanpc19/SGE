window.onload = inicializaEventos;

function inicializaEventos() {
    boton = document.getElementById("btnSaludo");
    boton.addEventListener("click", saludar, false);
}

function saludar() {
    //alert("hola");
    let miLlamada = new XMLHttpRequest();
    let divMensaje = document.getElementById("mensaje");

    //miLlamada.open("GET", "http://127.0.0.1:5500/Hola.html");
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/personas");
    
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            divMensaje.innerHTML = "Cargando...";

        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            //let response = miLlamada.responseText;
            //divMensaje.textContent = response;

            let response = JSON.parse(miLlamada.responseText);
            divMensaje.innerHTML=response[0].nombre;
        }
        
    };
    miLlamada.send();
}