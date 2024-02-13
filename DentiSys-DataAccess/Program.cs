using Dapper;
using DentiSys_DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;

var connectionString = "Server=localhost;Database=DB_DentiSys_DataAcces;User ID=sa;Password=root; TrustServerCertificate=true";

var patient = new Patient()
{
    Id = Guid.NewGuid(),
    Name = "Flavin do Pneu",
    Age = 19,
    Height = 1.85,
    weight = 59
};

var insertPatients = @"insert into 
        [Patients] 
    VALUES (
        @IdParam,
        @NameParam,
        @AgeParam,
        @HeightParam,
        @WeightParam)";

using(var connection = new SqlConnection(connectionString))
{
    // retorna a quanidade de linhas afetadas
    var rows = connection.Execute(insertPatients, new 
    {
        IdParam = patient.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
        NameParam = patient.Name, //patient.Name
        AgeParam = patient.Age,
        HeightParam = patient.Height,
        WeightParam = patient.weight
    });
    Console.WriteLine($"{rows} linhas iseridas");

    var patientsList = connection.Query<Patient>("SELECT * FROM PATIENTS");
    foreach (var item in patientsList)
    {
        Console.WriteLine($"{item.Name} - {item.Age} - {item.Height} - {item.weight}");
    }

}