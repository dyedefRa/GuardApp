using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class GuardPersonal
    {
        public int Id { get; set; }
        public int GuardId { get; set; }
        public virtual Guard Guard { get; set; }
        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }


        public string GetFullName()
        {
            string fullName = Personal.Term + " " + Personal.Rank.Name + " " + Personal.Name;

            return fullName;
        }
    }
}
