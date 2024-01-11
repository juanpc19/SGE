// JavaScript source code

//alert("cosa")
window.onload = lanzaEvento

function cambiarTitulo()
{
    var misH2;
    var miBoton;

    document.getElementById("mialo").innerHTML = "sacadme de aqui" //para id
    document.getElementsByTagName("h2")[1].innerHTML = "sos" //para h2 pos x
    
    misH2 = document.getElementsByTagName("h2") //para todos los h2
    alert(misH2) //alerta con objeto misH2
    misH2[0].innerHTML = "weeee"

    //camba los obejtos misH2
    for (var i = 0; i < misH2.length; i++) {
        misH2[i].innerHTML = "rip"
    }

    miBoton = document.getElementById("btn")
    miBoton.value = "Ya has cambiado"//valor boton
    miBoton.disabled=true//deshabilitar boton

}

//añade esta parte al boton onclick="cambiarTitulo()"
function lanzaEvento() {
    document.getElementById("btn").addEventListener("click", cambiarTitulo, false)
}
