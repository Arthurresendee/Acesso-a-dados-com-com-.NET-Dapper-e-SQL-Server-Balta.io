using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public double Height { get; set; }
        public double weight { get; set; }
    }
}
