using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class Rank
    {
        public int Id { get; set; }
        [DisplayName("Rütbe Adı")]
        public string Name { get; set; }
        [DisplayName("Rütbe Sırası")]
        public int Number { get; set; }
        public override string ToString()
        {
            return Name;
        }       
   }
}
