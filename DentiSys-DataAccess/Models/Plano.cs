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
        public TipoDePlano TipoDePlano{ get; set; }
        public string Nome { get; set; }
        public string Decricao { get; set; }
        public string Cobertura { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; }
    }
}
