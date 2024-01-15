using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Data;

// connectionString
string connectionString = "Data Source=(localdb)\\demo01ado; Integrated Security=True; Database=Contact";

//// Création d'un objet SQLConnection présent dans la librairie ADO.NET
SqlConnection connection = new SqlConnection(connectionString);

// Lire des enregistrements (Afficher la totalité des étudiants)
using (SqlConnection conn = new SqlConnection(connectionString))
{
    string req = "SELECT * FROM etudiant;";

    SqlCommand command = new SqlCommand(req, conn);

    try
    {
        conn.Open();

        // Lorsque l'on souhaite lire des enregistrements, on instancie un reader
        SqlDataReader reader = command.ExecuteReader();

        // La méthode Read renvoie vraie tant qu'il y a des enregistrements
        while (reader.Read())
        {
            // On récupère la valeur d'un enregistrement grâce à son index
            Console.WriteLine($"id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)}, numeroClasse: {reader.GetString(3)}, dateDiplome: {reader.GetString(3)}");
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

// Lire des enregistrements (Afficher les étudiants d'une classe)
using (SqlConnection conn = new SqlConnection(connectionString))
{
    string req = "SELECT * FROM etudiant WHERE numeroClasse=@numeroClasse;";

    int numeroClasse = int.Parse(Console.ReadLine());

    SqlCommand command = new SqlCommand(req, conn);

    command.Parameters.AddWithValue("@numeroClasse", numeroClasse);

    try
    {
        conn.Open();

        // Lorsque l'on souhaite lire des enregistrements, on instancie un reader
        SqlDataReader reader = command.ExecuteReader();

        // La méthode Read renvoie vraie tant qu'il y a des enregistrements
        if (reader.Read())
        {
            // On récupère la valeur d'un enregistrement grâce à son index
            Console.WriteLine($"id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)}, numeroClasse: {reader.GetString(3)}, dateDiplome: {reader.GetString(3)}");
        }
        else
        {
            Console.WriteLine($"Aucun étudiant n'a été trouvé dans la classe {numeroClasse}");
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}