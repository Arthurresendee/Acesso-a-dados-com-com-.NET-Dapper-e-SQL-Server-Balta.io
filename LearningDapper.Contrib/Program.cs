using Blog.Models;
using Blog_DapperDataAccess.Repositories;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING= "Server=localhost;Database=Blog-LearningDapperContrib;User ID=sa;Password=root; TrustServerCertificate=true";
var connection = new SqlConnection(CONNECTION_STRING);


connection.Open();

    Console.WriteLine("\n--------------GETALL com roles-----------------");
    ReadUsers(connection);

    Console.WriteLine("\n--------------DELETEID-----------------");
    DeleteUser(connection, 9);

    Console.WriteLine("\n--------------GETID-------------");
    ReadUser(connection, 3);

    Console.WriteLine("\n---------------UPDATE----------------------");

    var user = new User()
    {
        Name = "Arthur",
        Email = "resende@gmail.com",
        Bio = "pipipipopopo",
        Slug = "arhur"
    };

    UpdateUser(connection, 3, user);

Console.WriteLine("\n---------------GetOneToOne----------------------");


connection.Close();


static void ReadUsers( SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var items = repository.GetWithRoles();                   //OneToOne

    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
        foreach (var item1 in item.Roles)
        {
            Console.WriteLine($"      - {item1.Name}");
        }
    }
}

static void ReadUser( SqlConnection connection, int id)
{
    var repository = new Repository<User>(connection);
    var user = repository.Get(id);

    if (user == null)
        Console.WriteLine("Usuário não encontrado");
    else
        Console.WriteLine($"Nome: {user.Name} - Email: {user.Email}");
}

static void DeleteUser(SqlConnection connection, int id)
{
    var repository =  new Repository<User>(connection);
    var userToDelete = repository.Get(id);

    if (userToDelete == null)
        Console.WriteLine("Usuário não encontrado");
    else
    {
        repository.Delete(userToDelete);
        Console.WriteLine("Usuário deletado com sucesso.");
    }
}
static void UpdateUser(SqlConnection connection, int id, User userAtualizado)
{
    var repository = new Repository<User>(connection);
    var userToUpdate = repository.Get(id);

    if (userToUpdate == null)
        Console.WriteLine("Usuário não encontrado.");
    else
    {
        userToUpdate.Name = userAtualizado.Name;
        userToUpdate.Email = userAtualizado.Email;
        userToUpdate.Bio = userAtualizado.Bio;
        userToUpdate.Slug = userAtualizado.Slug;

        repository.Update(userToUpdate);
        Console.WriteLine("Usuário atualizar com sucesso.");
    }

}
static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var items = repository.Get();

    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
    }
}
static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var items = repository.Get();

    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
    }

}
static void UpdateTag(SqlConnection connection,Tag tag, int id)
{
    var repository = new Repository<Tag>(connection);

    var newTag = new Tag()
    {
        Name = "Generico",
        Slug = "generico"
    };

    var item = repository.Get(id);
    if (item != null)
    {
        repository.Update(tag);
        Console.WriteLine("Registro atualizado com sucesso");
    }
    else
    {
        Console.WriteLine("Registro não encontrado para atualizar");
    }
}



//#region Roles
//static void ReadRoles(SqlConnection connection)
//{
//    var roleRepository = new RoleRepository(connection);
//    var roles = roleRepository.Get();

//    foreach (var item in roles)
//        Console.WriteLine($"{item.Name} - {item.Slug}");
//}

//static void CreateRole(SqlConnection connection)
//{
//    var roleRepository = new RoleRepository(connection);

//    var role = new Role()
//    {
//        Id = 6,
//        Name = "Autor1",
//        Slug = "author1"
//    };

//    roleRepository.Create(role);
//    Console.WriteLine("Cadastro Realizado com sucesso.");
//}

//static void UpdateRole(SqlConnection connection)
//{
//    var roleRepository = new RoleRepository(connection);

//    var role = new Role()
//    {
//        Name = "Instrutor",
//        Slug = "instructor"
//    };

//    roleRepository.Update(role);
//    Console.WriteLine("Atualização Realizada com sucesso.");
//}
//#endregion

//#region Users
//static void ReadUsers(SqlConnection connection)
//{
//    var userRepository = new UserRepository(connection);
//    var users = userRepository.Get();

//    foreach (var item in users)
//        Console.WriteLine(item.Name);
//}

//static void ReadUser(SqlConnection connection)
//{
//    var userRepository = new UserRepository(connection);

//    var user = userRepository.Get(1);
//    Console.WriteLine(user.Name);
//}

//static void CreateUser(SqlConnection connection)
//{
//    var userRepository = new UserRepository(connection);

//    var user = new User()
//    {
//        Name = "Equipe Balta",
//        Email = "Oi@balta.io",
//        PasswordHash = "HashCode",
//        Bio = "Equipe Balta.io",
//        Image = "https://...",
//        Slug = "Equipe-balta-1"
//    };

//    userRepository.Create(user);
//    Console.WriteLine("Cadastro Realizado com sucesso.");
//}

//static void UpdateUser(SqlConnection connection)
//{
//    var userRepository = new UserRepository(connection);    
//    var user = new User()
//    {
//        Id = 1,
//        Name = "Equipe Balta",
//        Email = "xXXX@balta.io",
//        PasswordHash = "HashCode",
//        Bio = "Equipe Balta.io",
//        Image = "https://...",
//        Slug = "XXX-balta-1"
//    };

//    userRepository.Update(user);
//    Console.WriteLine("Atualização Realizada com sucesso.");
//}

//static void DeleteUser(SqlConnection connection)
//{
//    var userRepository = new UserRepository(connection);

//    var user = userRepository.Get(2);
//    if (user != null)
//    {
//        userRepository.Delete(user);
//        Console.WriteLine("Usuário Escluído");
//    }
//    else
//        Console.WriteLine("Usuário não encontrado.");
//}

//#endregion

