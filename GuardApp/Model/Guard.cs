using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
   public class Guard
    {
        public int Id { get; set; }
        [DisplayName("Nöbet Adı")]
        public string Name { get; set; }
        [DisplayName("Aktif mi?")]
        public bool IsActive { get; set; } = true;
    }
}
