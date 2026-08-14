namespace tp05.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Password { get; set; }

    public Usuario(int id, string nombre, string password)
    {
        Id = id;
        Nombre = nombre;
        Password = password;
    } 
    //copilot me autocompleto esto
}
