using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Endereco
    {

        public Guid Id { get; set; }
        public string CEP {get;set;}
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
    }
    
}
