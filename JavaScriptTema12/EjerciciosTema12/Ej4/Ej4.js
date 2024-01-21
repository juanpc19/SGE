window.onload = InicializaEventos;

var tabla;

function InicializaEventos() {
    document.getElementById("btnAlert").addEventListener("click", RecorrerCeldas, false);
    document.getElementById("btnAdd").addEventListener("click", AnadirCelda, false);
    document.getElementById("btnDelete").addEventListener("click", BorrarCelda, false);
    tabla = document.getElementById("tabla");
}

//recorre celdas y muestra contenido de estas en alert al final de iteraciones 
function RecorrerCeldas() {
    let mensajeAlerta = "";
    let lastRowIndex = tabla.rows.length - 1;
    let lastCellIndex = tabla.rows[lastRowIndex].cells.length - 1;

    for (var i = 0; i < tabla.rows.length; i++) {

        for (var j = 0; j < tabla.rows[i].cells.length; j++) {

            if (tabla.rows[i].cells[j] == lastCellIndex) {
                mensajeAlerta += tabla.rows[i].cells[j].innerHTML;  
            } else {
                mensajeAlerta += tabla.rows[i].cells[j].innerHTML;
                mensajeAlerta += ", ";
            }  
        }
    }
    alert(mensajeAlerta);//el alert añade una coma innecesario al final pero pereza
}

function AnadirCelda() {
    let lastRowIndex = tabla.rows.length - 1;//ultima fila de la tabla

    let lastCellIndex = tabla.rows[lastRowIndex].cells.length - 1;//ultima celda de la ultima fila

    let celdasUltimaFila = tabla.rows[lastRowIndex].cells.length;//cuenta celdas para establecer longitud de la fila

    let contenido = "celda";  

    ////si hay hueco en la fila
    if (celdasUltimaFila == 1) {
        //guardo posicion de celda que voy a crear para usarla en asignacion de valor e inserto la celda
        let nuevaCelda1 = tabla.rows[lastRowIndex].insertCell(1);

        contenido += (lastRowIndex+1).toString();//añado index de ultima fila+1 a contenido para indicar fila
        contenido += "2";//añado 2 a contenido para indicar columna, añado 2 manual porque se que hay 2 columnas 
        nuevaCelda1.innerHTML = contenido; //le meto contenido a la nueva celda   

        //de lo contrario es 2 crear nueva fila y añadir celda a la fila por lo next check sera ==1
    } else {
        tabla.insertRow(lastRowIndex + 1);//+1 a lastRowIndex para insertar fila justo debajo de la ultima actual

        lastRowIndex = tabla.rows.length - 1;//recalculo lastRowIndex porque acabo de insertar fila

        //guardo posicion de celda que voy a crear para usarla en asignacion de valor e inserto la celda
        let nuevaCelda2 = tabla.rows[lastRowIndex].insertCell(0);//+1 a lastRowIndex porque acabo de insertar fila, asi pillo la "nueva ultima fila"

        contenido += (lastRowIndex + 1).toString();//añado index de ultima fila+1 a contenido para indicar fila
        contenido += "1";//añado 1 a contenido para indicar columna, añado 1 manual porque se que hay 2 columnas
        nuevaCelda2.innerHTML = contenido; //le meto contenido a la nueva celda
    }
}

//borrar ultima celda de la ultima fila o fila si esta vacia
function BorrarCelda() {
    let lastRowIndex = tabla.rows.length - 1;//ultima fila de la tabla

    let lastCellIndex = tabla.rows[lastRowIndex].cells.length - 1;//ultima celda de la ultima fila

    let celdasUltimaFila;//cuenta celdas para establecer longitud de la fila
    
    tabla.rows[lastRowIndex].deleteCell(lastCellIndex);//borra ultima celda de la ultima fila de la tabla

    celdasUltimaFila = tabla.rows[lastRowIndex].cells.length;//calculo celdasUltimaFila cuando acabo de borrar celda

    //si la ultima fila esta vacia la borro
    if (celdasUltimaFila == 0) {
        tabla.deleteRow(lastRowIndex);
    }
}
