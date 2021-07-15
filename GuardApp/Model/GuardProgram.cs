using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class GuardProgram
    {
        public int Id { get; set; }
        public int GuardPersonalId { get; set; }
        public virtual GuardPersonal GuardPersonal { get; set; }
        public DateTime Date { get; set; }
    }
}
