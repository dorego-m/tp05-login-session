

function AttemptSignUp()
{
var formulario = document.getElementById("form");

var username = document.getElementById("username").value;
var nombre = document.getElementById("nombre").value;
var apellido = document.getElementById("apellido").value;
var contraseña = document.getElementById("contraseña").value;

//NOMBRE CHECK

check1 = SPCharacterCheck(nombre, "Nombre", "nombreLabel");

//APELLIDO CHECK

check2 = SPCharacterCheck(apellido, "Apellido", "apellidoLabel");


//USERNAME CHECK
//la logica de estos es que si esta bien todo, no muestra nada, si hay menos que 8 characteres, siempre muestra esa alerta, y si no entonces muestra la de characteres especiales

check3 = SPCharacterCheck(username, "Username", "usernameLabel");
check4 = LengthCheck(username, "Username", "usernameLabel");

//PASSWORD CHECK

check5 = LengthCheck(contraseña, "Contraseña", "passwordLabel");

if(check1 == "todoBien" && check2 == "todoBien" && check3 == "todoBien" && check4 == "todoBien" && check5 == "todoBien")
{
    formulario.requestSubmit()
}

}

function SPCharacterCheck(textToTest, P, Label) 
{
//esto lo consegui de https://stackoverflow.com/questions/32311081/check-for-special-characters-in-string
//estaba deprecated entonces busque como arreglarlo (con IA)

    var format = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    //            ^                                       ^   
    var check = "todoBien";

if (format.test(textToTest)) 
    {
        document.getElementById(Label).textContent = P + " no puede tener characteres especiales";
        check = "MAL";
    }
else 
    {
        document.getElementById(Label).textContent = "";
    }

    return check;
}

function LengthCheck(textToTest, P, Label) 
{
    var check = "todoBien";
    if (textToTest.length < 8) 
    {
        document.getElementById(Label).textContent = P + " debe ser mas largo que 8 caracteres";
        check = "MAL";
    }

    return check;
}
