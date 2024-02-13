using Dapper;
using DentiSys_DataAccess.Models;
using Microsoft.Data.SqlClient;

var connectionString = "Server=localhost;Database=DB_DentiSys_DataAcces;User ID=sa;Password=root; TrustServerCertificate=true";

var patient = new Patient()
{
    Id = Guid.NewGuid(),
    Name = "Flavin do Pneu",
    Age = 19,
    Height = 1.85,
    weight = 59
};

var insertPatients = "insert into [Patients] VALUES (Name, Age, Height, Weight)";

using(var connection = new SqlConnection(connectionString))
{

    var patientsList = connection.Query<Patient>("SELECT * FROM PATIENTS");
    foreach (var item in patientsList)
    {
        Console.WriteLine($"{item.Name} - {item.Age} - {item.Height} - {item.weight}");
    }

}