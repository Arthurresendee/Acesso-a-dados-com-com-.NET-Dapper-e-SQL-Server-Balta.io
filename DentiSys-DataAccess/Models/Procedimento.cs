using DentiSys_DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Procedimento
    {
        public Procedimento()
        {
            PacienteProcedimentos = new List<PacienteProcedimento>();
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public TipoDeProcedimento TipoDeProcedimento { get; set; }
        public string Descricao { get; set; }
        public IList<PacienteProcedimento> PacienteProcedimentos { get; set; }
        //public IList<DateTime> DataProcedimentos { get; set; } //data em que um determinado procedimento foi realizado ou agendado para ser realizado
    }
}
