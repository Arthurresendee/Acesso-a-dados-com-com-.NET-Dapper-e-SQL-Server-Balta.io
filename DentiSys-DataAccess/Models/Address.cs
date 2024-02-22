using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class Address
    {
        public Address() { }

        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string ZIPCode {get;set;}
    }
    
}
