namespace tp05.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Password { get; set; }
    public string TipoUsuario { get; set; }

    public Usuario(int id, string nombre, string apellido, string password, string tipoUsuario)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Password = password;
        TipoUsuario = tipoUsuario;
    } 
    //copilot me autocompleto esto
}
