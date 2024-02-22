using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentiSys_DataAccess.Models
{
    public class PatientPlan
    {
        public PatientPlan() { }
        public Guid PatientId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
    }
}
