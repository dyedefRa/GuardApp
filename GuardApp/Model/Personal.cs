using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
   public class Personal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public bool IsActive { get; set; }


        public Rank Rank { get; set; }
    }
}
