window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("btn").addEventListener("click",enviar, false)
}

class Persona {
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
}

function enviar()
{   
    var nombre;
    var apellidos;

    nombre = document.getElementById("nombre").value;
    apellidos = document.getElementById("apellidos").value;

    var p = new Persona(nombre, apellidos);
    alert("nombre: " + p.nombre + " apellidos: " + p.apellidos);
}