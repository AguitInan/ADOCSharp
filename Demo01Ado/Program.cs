// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\demo01ado; Integrated Security=True ; Database=Contact";

SqlConnection connection = new SqlConnection(connectionString);


connection.Open();

if (connection.State == ConnectionState.Open)
{
    Console.WriteLine("La connexion est ouverte!");
}
else
{
    Console.WriteLine("La connexion n'est pas ouverte :(");
}

// Requête

Console.WriteLine("Prenom");
string prenom = Console.ReadLine() ?? "";
Console.WriteLine("Nom");
string nom = Console.ReadLine() ?? "";
Console.WriteLine("Email");
string email = Console.ReadLine() ?? "";

string req = $"INSERT INTO personne (prenom, nom, email) VALUES ('{prenom}','{nom}','{email}')";

SqlCommand command = new SqlCommand(req, connection);

int rowsAffected = command.ExecuteNonQuery();

Console.WriteLine(rowsAffected);

command.Dispose();

connection.Close();

