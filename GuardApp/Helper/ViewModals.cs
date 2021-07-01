using GuardApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Helper
{
    public class ViewModals
    {
        public class PersonalModel
        {
            public int Id { get; set; }
            [DisplayName("Rütbesi")]
            public string Rank { get; set; }
            [DisplayName("Ad / Soyad")]
            public string Name { get; set; }
            [DisplayName("Dönemi")]
            public string Term { get; set; }
            [DisplayName("Aktif Mi?")]
            public bool IsActive { get; set; }

        }

        public List<PersonalModel> ConvertPersonalModel(List<Personal> personals)
        {
            return personals.Select(x =>
             {
                 return new PersonalModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Term = x.Term,
                     Rank = x.Rank.Name,
                     IsActive = x.IsActive
                 };
             }).ToList();
        }
    }
}
