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

var connectionString = "Server=localhost;Database=DentiSys;User ID=sa;Password=root; TrustServerCertificate=true";

using(var connection = new SqlConnection(connectionString))
{
    //ListarTodos(connection);
    //GetPatient(connection, new Guid("B2A83A96-4EDC-4E3B-BF1D-1C27CF90375F"));
    //CriarPaciente(connection);
    //UpdatePaciente(connection, new Guid("57AA0262-F430-4F3D-AE01-9C72F21FBC3F"));
    //DeletarPaciente(connection, new Guid("57AA0262-F430-4F3D-AE01-9C72F21FBC3F"));
    //CriarMuitosPacientes(connection);
    //ExecuteDeleteProcedure(connection, new Guid("B3DE8154-BA20-435B-8686-01C1519DB13F"));
    //ExecuteProcedureGetPacientes(connection);
    //ExecuteProcedureGetPacienteById(connection, new Guid("B2A83A96-4EDC-4E3B-BF1D-1C27CF90375F"));
    //ExecuteScalar(connection);
    //ReadView(connection);
    //OneToOneErrado(connection);
    //OneToOne(connection);
    //OneToMany(connection);
    //QueryMultiple(connection);
    //SelectIn(connection);
    Like(connection, "Tratamento");
}

static void ListarTodos(SqlConnection connection)
{
    var patientsList = connection.Query<Paciente>("select * from Paciente");
    foreach (var item in patientsList)
    {
        Console.WriteLine($"{item.Id} - {item.Nome} - {item.Idade}");
    }
}

static void GetPatient(SqlConnection connection, Guid idGuid)
{
    var getSQL = ("SELECT * FROM Paciente where Id = @id");

    var paciente = connection.QueryFirstOrDefault<Paciente>(getSQL, new
    {
        id = idGuid
    });

    Console.WriteLine($" Id = {paciente.Id}\n Nome = {paciente.Nome}\n Idade = {paciente.Idade}\n Sobrenome = {paciente.SobreNome}");
}

/*Sempre que temos um create, update ou delete, temos um retorno como int, de quantos registro foram afetados, igual aos do sql server*/
static void CriarPaciente(SqlConnection connection)
{
    var patient = new Paciente()
    {
        Id = Guid.NewGuid(),
        Nome = "Flavin do Pneu",
        Idade = 19,
        Email = "Arthurresende2004@gmail.com",
        IdEndereco = new Guid("1F25D9D7-C9DE-4F9A-8D59-5416D8DAAE13"),
    };

    //Se os dados estivem em sequência, não precisar definir as colunas.   
    var insertSQL = @"insert into 
        [Paciente]
        (Id, Nome, Idade, Email, IdEndereco)
    VALUES (
        @paramId,
        @paramNome,
        @paramIdade,
        @paramEmail,
        @paramIdEndereco)";

    // retorna a quanidade de linhas afetadas
    //var rows = connection.ExecuteScalar<Guid>() O execute scalar serve para  recuperarmos um valor unico em uma tabela. Normalemnte criamos o objeto e já pegamos o IdDele. No sql normalmente é o SCOPE_IDENTITY()
    var rows = connection.Execute(insertSQL, new
    {
        paramId = patient.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
        paramNome = patient.Nome, //patient.Name
        paramIdade = patient.Idade,
        paramEmail = patient.Email,
        paramIdEndereco = patient.IdEndereco
    });
    Console.WriteLine($"Create - {rows} linhas inseridas");
}

static void UpdatePaciente(SqlConnection connection, Guid idPaciente)
{
    var updateQuery = "UPDATE [Paciente] set Nome = @novoNome where Id = @idDoPacienteParaAtualizar";

    var rows = connection.Execute(updateQuery, new
    {
        idDoPacienteParaAtualizar = idPaciente,
        novoNome = "Serjão Berranteiro  "
    });
    Console.WriteLine($"Update - {rows} registros atualizados");
}

static void DeletarPaciente(SqlConnection connection, Guid idPaciente)
{
    var deleteSQL = "Delete [Paciente] where Id = @idDoPacienteParaDeletar";
    var rows = connection.Execute(deleteSQL, new
    {
        //id = new Guid("fc47b520-9bd8-4c5b-a9fd-01fc89c720d6")
        idDoPacienteParaDeletar = idPaciente
    });
    Console.WriteLine($"Delete - {rows} linhas excluídas");
}

static void CriarMuitosPacientes(SqlConnection connection)
{
    var patient = new Paciente()
    {
        Id = Guid.NewGuid(),
        Nome = "Bam Bam",
        Idade = 50,
        Email = "naopossui@gmail.com",
        IdEndereco = new Guid("7B5A3D89-625E-439F-AF3E-F29E0FF2C4CB")
    };
    var patient2 = new Paciente()
    {
        Id = Guid.NewGuid(),
        Nome = "Jão",
        Idade = 32,
        Email = "Jao244@gmail.com ",
        IdEndereco = new Guid("D7484AB8-B62C-4F4F-BC57-F1CFEA3E5607")
    };

    var insertSQL = @"insert into 
        [Paciente] 
        (Id, Nome, Idade, Email,IdEndereco)
    VALUES (
        @paramId,
        @paramNome,
        @paramIdade,
        @paramEmail,
        @paramIdEndereco)";

    // Usamos o mesmo modelo de string sql para inserir vários objetos diferentes
    var rows = connection.Execute(insertSQL, new[]
    {
        new
        {
            paramId = patient.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
            paramNome = patient.Nome, //patient.Name
            paramIdade = patient.Idade,
            paramEmail = patient.Email,
            paramIdEndereco = patient.IdEndereco
        },
        new
        {
            paramId = patient2.Id, //patient.Id/ Quando o parâmetro for o mesmo nome, pode somente colocar a propriedade no objeto anônimo.
            paramNome = patient2.Nome, //patient.Name
            paramIdade = patient2.Idade,
            paramEmail = patient2.Email,
            paramIdEndereco = patient2.IdEndereco
        }
    });
    Console.WriteLine($"Create - {rows} linhas inseridas");
}

/*Os parâmetros passados para execução de uma procedure tem que ter o mesmo nomes do Parâmetro que foi criado no banco de dados. O Dapper faz esse mapeamento automático, então tem que ser igual.*/
static void ExecuteDeleteProcedure(SqlConnection connection, Guid id)
{
    var procedure = "spDeletePaciente";
    var param = new { @idPaciente = id };
    var affectedRows = connection.Execute(
        procedure,
        param,
        commandType: CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} linhas afetadas");
}

static void ExecuteProcedureGetPacientes(SqlConnection connection)
{
    var procedure = "spGetPacientes";
    var patients = connection.Query<Paciente>(
        procedure,
        commandType: CommandType.StoredProcedure);

    foreach (var item in patients)
    {
        Console.WriteLine($"Id:{item.Id} - Nome:{item.Nome}\n");
    }
}

static void ExecuteProcedureGetPacienteById(SqlConnection connection, Guid id)
{
    var procedure = "spGetPacienteById";
    var param = new { @id = id };
    var patient = connection.Query<Paciente>(
        procedure,
        param,
        commandType: CommandType.StoredProcedure).FirstOrDefault();

    Console.WriteLine($"Id: {patient.Id} - Nome: {patient.Nome}\n");

}

/*Executamos em escalar quando queremos um retorno diferente. Ex: ao invés de pegarmos o 
* retorno em INT que é quantas linhas foram afetadas no ato de um insert, update ou delete, 
* pegamos como exemplo o Id do objeto que inserimos, ou guid*/
static void ExecuteScalar(SqlConnection connection)
{
    var paciente = new Paciente()
    {
        //Id = Guid.NewGuid(),
        Nome = "Pedro",
        Idade = 20
    };

    var insertSQL = @"
    insert into 
        [Paciente]
        (Id, Nome, Idade, IdEndereco)
    OUTPUT inserted.Id
    VALUES 
        (
        NEWID(),
        @parametroNome,
        @parametroIdade,
        @parametroIdEndereco
        )";
    //Select SCOPE_IDENTITY()"; 
    // O scope identity não funciona quando o Id não é do tipo identity seed, então como o guid não é inteiro, para o guid o identity não funciona.
    // Nesse caso podemos usar o OUTPUT inserted.Id, que queremos pegar o valor do campo inserido

    var id = connection.ExecuteScalar<Guid>(insertSQL, new //Como o scalar é simples, não conseguimos trazer uma série de colunas ou um objeto
    {
        parametroId = paciente.Id,
        parametroNome = paciente.Nome, //patient.Name
        parametroIdade = paciente.Idade,
        parametroIdEndereco = new Guid("5C28E04B-9F6E-4B75-883F-47937E93D118")
    });
    Console.WriteLine($"Create - Id gerado: {id}");
}

static void ReadView(SqlConnection connection)
{
    var sql = "select * from vwTodosOsPacientes";

    var patients = connection.Query<Paciente>(sql);

    foreach (var item in patients)
    {
        Console.WriteLine($"Id: {item.Id}, Name: {item.Nome} \n");
    }
}

static void OneToOneErrado(SqlConnection connection)
{
    //Funciona? sim. Está errado? Sim, pois não estamos mapeando para um objeto em sí. Estamos pegando os valores de uma coluna do relacionamento com tipo dinâmico, Podendo existir ou não essa coluna. Como estamos retornando valores de um select que possui relacionamento, precisamos tranformar em objeto no c#, por isso estamos utilizando dapper. Justamente para transformar o que vem do SQL SERVER em objeto..
    var sql = @"
        select 
          *
        from 
            Paciente
        inner join 
            Endereco ON Paciente.IdEndereco = Endereco.Id";

    var items = connection.Query(sql);

    foreach (var item in items)
    {
        Console.WriteLine(item.Teste);
    }
}

/*Como sempre utilizamos a orientação a ojetos, queremos mapear para os objetos específicos
  como Endereco e Paciente. Queremos ter de fato um objeto dentro do outro*/
static void OneToOne(SqlConnection connection)
{
    var sql = @"
        select 
          Paciente.Id,
          Paciente.Nome,
          Endereco.Id as IdDoEndereco,
          Endereco.CEP,
          Endereco.Estado
        from 
            Paciente
        inner join 
            Endereco ON Paciente.IdEndereco = Endereco.Id";

    var items = connection.Query<Paciente, Endereco, Paciente>(//Eu tenho um Paciente, mas também tenho um Endereco, e o resultado dessa consulta será um Paciente
        sql,    //depois da instrução sql, tenho que dizer como que vai carregar esse praciente pra mim Fazemos isso atravé de uma função () => {}
        (Paciente paciente, Endereco endereco) => // ( , ) => {}  //(paciente, endereco) =>
        {
            paciente.Endereco = endereco;   //O que estou dizendo aqui? Que o Objeto Endereco que vier dentro de Paciente, será do tipo complexo Endereco
            return paciente;                    // Aqui eu estou retornando um Objeto do tipo Paciente que possui um Endereco dentro dele.
        }, splitOn: "IdDoEndereco");   //Última informação que temos que passar é onde a consulta é dividida.

    foreach (var item in items) //Como resultado, nós temos os dois objetos populados
    {
        Console.WriteLine($"Id: {item.Id}, Nome: {item.Nome}, Estado: {item.Endereco.Estado}");
    }
}

static void OneToManyP1(SqlConnection connection)
{
    var sql = @"
        select 
	        p.Id,
	        p.Nome,
            p.Sobrenome,
	        pp.IdPaciente,
	        pp.IdProcedimento,
	        pp.DataProcedimento
        from
	        Paciente p 
        inner join 
	        PacienteProcedimento pp on pp.IdPaciente = p.Id
	       order by p.Nome";

    var pacientes = connection.Query<Paciente, PacienteProcedimento, Paciente>(     //Eu tenho um Paciente, mas também tenho um Endereco, e o resultado dessa consulta será um Paciente
        sql,                                                //depois da instrução sql, tenho que dizer como que vai carregar esse praciente pra mim Fazemos isso atravé de uma função () => {}
        (paciente, pacienteProcedimento) =>       // ( , ) => {}  //(paciente, endereco) =>
        {                                      //O que estou dizendo aqui? Que o Objeto Endereco que vier dentro de Paciente, será do tipo complexo Endereco
            return paciente;                                                    // Aqui eu estou retornando um Objeto do tipo Paciente que possui um Endereco dentro dele.
        }, splitOn: "IdPaciente");                                            //Última informação que temos que passar é onde a consulta é dividida.

    foreach (var paciente in pacientes)                                                 //Como resultado, nós temos os dois objetos populados
    {
        Console.WriteLine($"Nome: {paciente.Nome},Sobrenome:{paciente.SobreNome}");
        foreach (var item in paciente.PacienteProcedimentos)                                                 //Como resultado, nós temos os dois objetos populados
        {
            Console.WriteLine($", IdProcedimento: {item.IdProcedimento}, DatadaProcedimento: {item.DataProcedimento}");
        }
    }
} //Aqui não populou os itens de PacienteProcedimento

static void OneToMany(SqlConnection connection)
{
    var sql = @"
        select 
	        p.Id,
	        p.Nome,
            p.Sobrenome,
	        pp.IdPaciente,
	        pp.IdProcedimento,
	        pp.DataProcedimento
        from
	        Paciente p 
        inner join 
	        PacienteProcedimento pp on pp.IdPaciente = p.Id
	       order by p.Nome";

    var pacientes = new List<Paciente>();
    var pacienteList = connection.Query<Paciente, PacienteProcedimento, Paciente>(
        sql,
        (paciente, pacienteProcedimento) =>
        {
            
            var pac = pacientes.Where(x => x.Id == paciente.Id).FirstOrDefault();
            if( pac == null)
            {
                pac = paciente;
                pac.PacienteProcedimentos.Add(pacienteProcedimento);
                pacientes.Add(pac);
            }
            else
            {
                pac.PacienteProcedimentos.Add(pacienteProcedimento);
            }

            paciente.PacienteProcedimentos.Add(pacienteProcedimento);
            return paciente;
        }, splitOn: "IdPaciente");

    foreach (var paciente in pacienteList)
    {
        Console.WriteLine($"Nome: {paciente.Nome},Sobrenome:{paciente.SobreNome}");
        foreach (var item in paciente.PacienteProcedimentos)
        {
            Console.WriteLine($"- IdProcedimento: {item.IdProcedimento}- DatadaProcedimento: {item.DataProcedimento}");
        }
    }
}

static void QueryMultiple(SqlConnection connection)
{
    var query = @"select *  from Paciente; 
                  select * from Procedimento";

    using (var multi = connection.QueryMultiple(query))
    {
        var pacientes = multi.Read<Paciente>();
        var procedimentos = multi.Read<Procedimento>();

        foreach (var item in pacientes)
        {
            Console.WriteLine($"IdPaciente: {item.Id}");
        }

        foreach (var item in procedimentos)
        {
            Console.WriteLine($"IdProcedimento: {item.Id}");
        }
    }
}

static void SelectIn(SqlConnection connection)
{
    var query = "select * from Paciente where Id in @Id";

    var items = connection.Query<Paciente>(query, new{
        Id = new[] {
            "FB0C3A72-B0F3-40E3-A234-1E33A3D90037",
            "B2A83A96-4EDC-4E3B-BF1D-1C27CF90375F",
            "0C58E61C-CE9D-44E3-A769-560A3DB82E4C"
        }
    });

    foreach (var item in items)
    {
        Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}");
    }
}

static void Like(SqlConnection connection, string term)
{
    var query = "select * from Procedimento where Descricao like @exp";

    var items = connection.Query<Procedimento>(query, new
    {
        exp = $"%{term}%"
    });

    foreach (var item in items)
    {
        Console.WriteLine($"Id: {item.Id} - Titulo: {item.Titulo} - Descricao: {item.Descricao}");
    }
}