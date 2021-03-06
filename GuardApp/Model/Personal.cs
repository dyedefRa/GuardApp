using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model
{
    public class Personal
    {
        public int Id { get; set; }
        [DisplayName("Ad / Soyad")]
        public string Name { get; set; }
        [DisplayName("Dönemi")]
        public string Term { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; } = true;
        public int RankId { get; set; }
        [DisplayName("Rütbesi")]
        public virtual Rank Rank { get; set; }
        public int PersonalUnityId { get; set; }
        [DisplayName("Birliği")]
        public virtual PersonalUnity PersonalUnity { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string GetIdentityForPdf()
        {
            string identityInformation = Rank?.Name + " " + Name + " " + " (" + Term + ")";
            return identityInformation;
        }
    }
}
