// JavaScript source code


//de una ya tiene set get a la mierda el tipo variable
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