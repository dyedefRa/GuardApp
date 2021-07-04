using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
  public  class GuardPersonal
    {
        public int Id { get; set; }
        public int GuardId { get; set; }
        public Guard Guard { get; set; }
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
    }
}
