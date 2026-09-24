const boton = document.getElementById("btnSubmit").value;
const formulario = document.getElementById("form").value;

function AttemptSignUp()
{
var username = document.getElementById("username").value;
var nombre = document.getElementById("nombre").value;
var apellido = document.getElementById("apellido").value;
var contraseña = document.getElementById("contraseña").value;

//esto lo consegui de https://stackoverflow.com/questions/32311081/check-for-special-characters-in-string
//estaba deprecated entonces busque como arreglarlo (con IA)

var format = /[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
//            ^                                       ^   
var textToTest = nombre
console.log(format.test(textToTest));


//LO QUE FALTA:

// chequea por cada error de nombre (if(!console.log(blahblahblah)))
//despues setea un label (sin texto originalmente) a el texto especifico del error (sumar texto y un /br si hay mas de un error)

}