using Dapper;
using Microsoft.Data.SqlClient;
using tp05.Models;

namespace tp05.Models;

public class BD
{
       private string _connectionString =
@"Server=localhost;
Database=usuarios;
Integrated Security=True;
TrustServerCertificate=True;";



//NuevoUsuario que recibe los elementos de un usuario y lo inserta en la base de datos
public void NuevoUsuario(string username, string nombre, string apellido, string password, string tipoUsuario)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        var query = "INSERT INTO Usuarios (Username, Nombre, Apellido, Password, TipoUsuario) VALUES (@Username, @Nombre, @Apellido, @Password, @TipoUsuario)";
        connection.Execute(query, new { Username = username, Nombre = nombre, Apellido = apellido, Password = password, TipoUsuario = tipoUsuario });
    }
}

//ValidarUsuario que devuelve el usuario al recibir username y password
//copilot me autocompleto esto
public Usuario ValidarUsuario(string username, string password)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        var query = "SELECT * FROM Usuarios WHERE Username = @Username AND Password = @Password";
        var usuario = connection.QueryFirstOrDefault<Usuario>(query, new { Username = username, Password = password });
        return usuario;
    }

}

public Usuario ValidarUsername(string username)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        var query = "SELECT * FROM Usuarios WHERE Username = @Username";
        var usuario = connection.QueryFirstOrDefault<Usuario>(query, new { Username = username });
        return usuario;
    }

}



}