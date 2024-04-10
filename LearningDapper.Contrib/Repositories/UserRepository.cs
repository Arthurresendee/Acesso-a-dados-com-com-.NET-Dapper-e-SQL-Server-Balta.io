using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_DapperDataAccess.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        //Estamos passando aqui a nossa conexão para o construtor da classe base, ou seja, para o repository.cs.
        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetWithRoles()
        {
            var query = @"select
	                [User].*,
	                [role].Id as IdRole,
	                [Role].[Name],
	                [Role].Slug
                from [user]
                left join UserRole on [User].Id = UserRole.UserId
                left join [Role] on [UserRole].RoleId = [Role].Id";

            var users =  new List<User>();

            var items = _connection.Query<User, Role, User>(
                query, (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);

                    if(usr == null)
                    {
                        usr = user;
                        if(role != null)
                            usr.Roles.Add(role); //Aqui a nossa lista de Roles tem que estar inicializada, se não dará erro. Por isso inicialiamos ela na classe de user.

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);


                    return user;
                }, splitOn: "IdRole"); //Aqui ele pega nossa query e divide em User e Role. 

            return users;
        }

    }
}
