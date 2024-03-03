using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Paciente : Pessoa
    {
        public Guid Id { get; set; }
        List<PacienteProcedimento> Procedimentos { get; set; }
        List<PacientePlano> Planos { get; set; }
        public DateTime CriacaoDoUsuario { get; set; }
    }
}
