using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class PersonalUnity
    {
        public int Id { get; set; }
        [DisplayName("Birlik Adı")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
