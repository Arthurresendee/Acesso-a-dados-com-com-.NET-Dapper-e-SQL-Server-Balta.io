using DentiSys_DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Plano
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public TipoDePlano TipoDePlano { get; set; }
        public string Descricao { get; set; }
        //public List<TipoDeProcedimento> Coberturas { get; set; }
        public string coberturas { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; }
    }
}
