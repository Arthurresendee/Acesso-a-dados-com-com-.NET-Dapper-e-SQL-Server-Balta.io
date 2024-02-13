using Dapper;
using DentiSys_DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.NetworkInformation;

var connectionString = "Server=localhost;Database=DB_DentiSys_DataAcces;User ID=sa;Password=root; TrustServerCertificate=true";

using(var connection = new SqlConnection(connectionString))
{
    //ListPatients(connection);
    GetPatient(connection,new Guid("8b037ee7-f124-4fa6-b551-0183c70eba57"));
    //CreatePatient(connection);
    //UpdatePatient(connection);
    //DeletePatiente(connection);
    //CreateManyPatients(connection);
}


static void ListPatients(SqlConnection connection)
{
    var patientsList = connection.Query<Patient>("SELECT * FROM PATIENTS");
    foreach (var item in patientsList)
    {
        Console.WriteLine($"{item.Name} - {item.Age} - {item.Height} - {item.weight}");
    }
}
static void GetPatient(SqlConnection connection,Guid idGuid)
{
    var getSQL = ("SELECT * FROM PATIENTS where Id = @id");

    var patient = connection.QueryFirstOrDefault<Patient>(getSQL, new
    {
        id = idGuid
    });

    Console.WriteLine($" Name = {patient.Name}\n Age = {patient.Age}\n Height = {patient.Height}\n Weight = {patient.weight}");
    
}
static void CreatePatient(SqlConnection connection)
{
    var patient = new Patient()
    {
        Id = Guid.NewGuid(),
        Name = "Flavin do Pneu",
        Age = 19,
        Height = 1.85,
        weight = 59
    };

    var insertSQL = @"insert into 
        [Patients] 
    VALUES (
        @idParam,
        @nameParam,
        @ageParam,
        @heightParam,
        @weightParam)";

    // retorna a quanidade de linhas afetadas
    var rows = connection.Execute(insertSQL, new
    {
        idParam = patient.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
        nameParam = patient.Name, //patient.Name
        ageParam = patient.Age,
        heightParam = patient.Height,
        weightParam = patient.weight
    });
    Console.WriteLine($"Create - {rows} linhas inseridas");
}
static void UpdatePatient(SqlConnection connection)
{
    var updateQuery = "UPDATE [Patients] set Name = @name where Id = @id";

    var rows = connection.Execute(updateQuery, new
    {
        id = new Guid("8b037ee7-f124-4fa6-b551-0183c70eba57"),
        name = "Zé da Manga"
    });
    Console.WriteLine($"Update - {rows} registros atualizados");
}
static void DeletePatiente(SqlConnection connection)
{
    var deleteSQL = "Delete [Patients] where @id = Id";
    var rows = connection.Execute(deleteSQL, new
    {
        id = new Guid("fc47b520-9bd8-4c5b-a9fd-01fc89c720d6")
    });
    Console.WriteLine($"Delete - {rows} linhas excluídas");
}

static void CreateManyPatients(SqlConnection connection)
{
    var patient = new Patient()
    {
        Id = Guid.NewGuid(),
        Name = "Bam Bam",
        Age = 50,
        Height = 1.45,
        weight = 120
    };
    var patient2 = new Patient()
    {
        Id = Guid.NewGuid(),
        Name = "Jão",
        Age = 32,
        Height = 1.61,
        weight = 86
    };

    var insertSQL = @"insert into 
        [Patients] 
    VALUES (
        @idParam,
        @nameParam,
        @ageParam,
        @heightParam,
        @weightParam)";

    // retorna a quanidade de linhas afetadas
    var rows = connection.Execute(insertSQL, new[]
    {
        new
        {
            idParam = patient.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
            nameParam = patient.Name, //patient.Name
            ageParam = patient.Age,
            heightParam = patient.Height,
            weightParam = patient.weight
        },
        new
        {
            idParam = patient2.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
            nameParam = patient2.Name, //patient.Name
            ageParam = patient2.Age,
            heightParam = patient2.Height,
            weightParam = patient2.weight
        }
    });
    Console.WriteLine($"Create - {rows} linhas inseridas");
}










