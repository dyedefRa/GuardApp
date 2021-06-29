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
        public Guard Guard { get; set; }
        public Personal Personal { get; set; }
        public DateTime Date { get; set; }
    }
}
