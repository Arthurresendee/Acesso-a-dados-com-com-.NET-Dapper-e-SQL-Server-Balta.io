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
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public TipoDeProcedimento TipoDeProcedimento { get; set; }
        public string Descricao { get; set; }
        //public List<DateTime> DataDoProcedimento { get; set; } //data em que um determinado procedimento foi realizado ou agendado para ser realizado
    }
}
