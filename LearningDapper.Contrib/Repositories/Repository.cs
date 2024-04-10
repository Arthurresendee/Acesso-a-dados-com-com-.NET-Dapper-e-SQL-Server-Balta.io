using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog_DapperDataAccess.Repositories
{
    public class Repository<TModel> where TModel : class
    {

        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        // O IEnumerable é o tipo base das listas, ele não permite que fazemos operações com essas listas, apenas percorrer. Se precisássemos de operações crud, utilizariamos o List
        //Só lembrando que essess métodos CRUD usados na _connection estão vindo da biblioteca do dapper.contrib

        public IEnumerable<TModel> Get() => _connection.GetAll<TModel>(); //ExpressionBody

        public TModel Get(int id) => _connection.Get<TModel>(id);

        public void Create(TModel tmodel) => _connection.Insert<TModel>(tmodel);

        public bool Update(TModel tmodel)
        {
            if (tmodel == null)
            {
                return false;
            }
            else
            {
                _connection.Update<TModel>(tmodel);
                return true;
            }
        }

        public bool Delete(TModel tmodel)
        {
            if (tmodel == null)
            {
                return false;
            }
            else
            {
                _connection.Delete<TModel>(tmodel);
                return true;
            }
        }
    }
}
