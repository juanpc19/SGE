// JavaScript source code

window.onload = Inicia;

function Inicia() {

    miInput=document.getElementById("miInput");
    miBoton=document.getElementById("miBoton");
    mensajeCorrecto=document.getElementById("mensajeCorrecto");
    mensajeError = document.getElementById("mensajeError");
    miP = document.getElementById("miP");
    miBoton.addEventListener("click", PeticionDeletePersona);
}

function PeticionDeletePersona() {

    miPeticion = new XMLHttpRequest();
    miPeticion.open("DELETE", "https://crudjuan.azurewebsites.net/api/personas/" + miInput.value);//añado a endpint el id de la persona a eliminar

    miPeticion.onreadystatechange = function () {

        if (miPeticion.readystate < 4) {
            miP.innerHTML = "Cargando...";
        }
        else if (miPeticion.readyState == 4) {
            miP.innerHTML = "";
            if (miPeticion.status == 200) {
                mensajeError.innerHTML = "";
                mensajeCorrecto.innerHTML = "Persona eliminada correctamente";
            } else {
                mensajeCorrecto.innerHTML = "";
                mensajeError.innerHTML = "Error al eliminar persona";
            }
        }
    };
    miPeticion.send();
}