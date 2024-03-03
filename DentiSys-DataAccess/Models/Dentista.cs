using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Dentista : Pessoa
    {
        public Guid Id { get; set; }
        public string Especializacao { get; set; }
        public string NumeroDeRegistro { get; set; } //Numero de registro emitido pela pregadora do curso superior
    }
}
