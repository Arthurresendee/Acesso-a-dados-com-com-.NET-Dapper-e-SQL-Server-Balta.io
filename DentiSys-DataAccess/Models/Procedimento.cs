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
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoDeProcedimento Type { get; set; }
        public List<DateTime> DataDoProcedimento { get; set; } //data em que um determinado procedimento foi realizado ou agendado para ser realizado
    }
}
