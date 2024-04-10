using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")] //Como nosso banco nossa tabela no sqlServer chama User e o dapper.contrib procura no plural "Users", usamos a notação para definir o nome da tabela que queremos procurar no sql server.
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [Write(false)]      // Isso é feito para não incluir roles na hora de salvar, na hora do insert
        public List<Role> Roles { get; set; }
    }
}