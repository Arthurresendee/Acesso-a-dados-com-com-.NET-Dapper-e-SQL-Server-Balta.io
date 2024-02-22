using Dapper;
using DentiSys_DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;
using System.Net.NetworkInformation;

/*
    O que o Dapper faz?
    Pega o quem vem do sql server no formato sqlDataRow e transforma para um objeto no c#
    Isso é tudo que o Dapper faz, por isso que ele é tão rápido.

    Dapper, uma biblioteca de mapeamento objeto-relacional (ORM) leve, que permite que você 
    mapeie os resultados de uma consulta SQL diretamente para objetos C#
 */



var connectionString = "Server=localhost;Database=DB_DentiSys_DataAcces;User ID=sa;Password=root; TrustServerCertificate=true";

using(var connection = new SqlConnection(connectionString))
{
    //ListPatients(connection);
    //GetPatient(connection,new Guid("8b037ee7-f124-4fa6-b551-0183c70eba57"));
    //CreatePatient(connection);
    //UpdatePatient(connection);
    //DeletePatiente(connection);
    //CreateManyPatients(connection);
    //ExecuteDeleteProcedure(connection, new Guid("b0f1649f-090e-4ab6-88c1-125486382c14"));
    //ExecuteGetProcedure(connection);
    //ExecuteGetProcedurebyId(connection, new Guid("8b037ee7-f124-4fa6-b551-0183c70eba57"));
    //ExecuteScalar(connection);

    //ReadView(connection);
    //OneToOne(connection);
    OneToOne2(connection);
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

                                                                /*Sempre que temos um create, update ou delete, temos um retorno como int, de quantos registro foram afetados, igual aos do sql server*/
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
    var rows = connection.ExecuteScalar<Guid>(insertSQL, new
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
static void ExecuteDeleteProcedure(SqlConnection connection,Guid id)
{
    var procedure = "spDeletePatient";
    var param = new { @idPatient = id };
    var affectedRows = connection.Execute(
        procedure,
        param,
        commandType: CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} linhas afetadas");
}

                                                            /*Os parâmetros passados para execução de uma procedure tem que ter o mesmo nomes do Parâmetro que foi criado no banco de dados. O Dapper faz esse mapeamento automático, então tem que ser igual.*/
static void ExecuteGetProcedure(SqlConnection connection)
{
    var procedure = "spGetPatient";
    var patients = connection.Query(
        procedure,
        commandType: CommandType.StoredProcedure);

    foreach (var item in patients)
    {
        Console.WriteLine($"{item.Id}");
    }
}

static void ExecuteGetProcedurebyId(SqlConnection connection, Guid id)
{
    var procedure = "spGetPatientById";
    var param = new { @id = id };
    var patient = connection.Query<Patient>(
        procedure,
        param,
        commandType: CommandType.StoredProcedure).FirstOrDefault();

        Console.WriteLine($"Id: {patient.Id}\n Name: {patient.Name}\n");

}

/*Executamos em escalar quando queremos um retorno diferente. Ex: ao invés de pegarmos o 
* retorno em INT que é quantas linhas foram afetadas no ato de um insert, update ou delete, 
* pegamos como exemplo o Id do objeto que inserimos, ou guid*/

static void ExecuteScalar(SqlConnection connection)
{
    var patient = new Patient()
    {
        //Id = Guid.NewGuid(),
        Name = "Pedro",
        Age = 20,
        Height = 1.75,
        weight = 85
    };

    var insertSQL = @"
    insert into 
        [Patients]
    OUTPUT inserted.Id
    VALUES (
        NewID(),
        @nameParam,
        @ageParam,
        @heightParam,
        @weightParam)";
        //Select SCOPE_IDENTITY()"; 
                                                            // O scope identity não funciona quando o Id não é do tipo identity seed, então como o guid não é inteiro, para o guid ele não funciona
                                                            // Nesse caso podemos usar o OUTPUT inserted.Id, que queremos pegar o valor do campo inserido

    var id = connection.ExecuteScalar<Guid>(insertSQL, new //Como o scalar é simples, não conseguimos trazer uma série de colunas ou um objeto
    {
        @nameParam = patient.Name, //patient.Name
        @ageParam = patient.Age,
        @heightParam = patient.Height,
        @weightParam = patient.weight
    });
    Console.WriteLine($"Create - Id gerado: {id}");
}

static void ReadView(SqlConnection connection)
{
    var sql = "select * from vwPatients";

    var patients = connection.Query<Patient>(sql);

    foreach (var item in patients)
    {
        Console.WriteLine($"Id: {item.Id}\n Name: {item.Name}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = @"
        select 
            * 
        from 
            PATIENTS 
        inner join 
            ADDRESSES ON PATIENTS.AddressId = ADDRESSES.Id";

    var items = connection.Query(sql);

    foreach(var item in items)
    {
        Console.WriteLine(item.Age);
    }
}

/*Como sempre utilizamos a orientação a ojetos, queremos mapeares para os objetos específicos
  como address e Patient. Queremos ter de fato um objeto dentro do outro*/
static void OneToOne2(SqlConnection connection)
{
    var sql = @"
        select 
            * 
        from 
            PATIENTS 
        inner join 
            ADDRESSES ON PATIENTS.AddressId = ADDRESSES.Id";

    var items = connection.Query(sql);

    foreach (var item in items)
    {
        Console.WriteLine(item.Street);
    }
}