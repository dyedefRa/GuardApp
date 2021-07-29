using GuardApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuardApp.Helper
{
    public class PDFHelper
    {
        public class PDFHelperViewModal
        {
            public string GuardName { get; set; }
            public int GuardNumber { get; set; }
            public List<PDFPersonalGuardDayModal> PersonalGuardList { get; set; }
        }

        public class PDFPersonalGuardDayModal
        {
            public int RankNumber { get; set; }
            public string PersonalInformation { get; set; }
            public string PersonalUnityName { get; set; }
            public List<DayNumberAndGuardNumbers> DayNumbersAndGuardNumbers { get; set; }
        }

        public class DayNumberAndGuardNumbers
        {
            public string DayNumber { get; set; }
            public string GuardNumbers { get; set; }
        }

        public static List<PDFHelperViewModal> GetPDFHelperModals(List<GuardProgram> guardPrograms)
        {
            List<PDFHelperViewModal> pDFHelperModals = new List<PDFHelperViewModal>();

            pDFHelperModals = guardPrograms
              .GroupBy(x => new { x.GuardPersonal.Guard }, (key, group) => new PDFHelperViewModal()
              {
                  //NOBETE GORE GRUPLANDI VE O NOBETIN PERSONELLERI GETIRILDI
                  //NÖBET ADI VE PERSONELLERI => x nöbeti ve y,z,k personelleri
                  GuardName = key.Guard.Name,
                  GuardNumber = key.Guard.Number,
                  PersonalGuardList = group.ToList()
                .GroupBy(y => new { y.GuardPersonal.Personal }, (key2, group2) => new PDFPersonalGuardDayModal()
                {
                    //PERSONELLERE GORE GRUPLANDI VE O PERSONELIN NOBET TARIHLERI GETIRILDI
                    //PERSONEL VE NOBET TARIHLERI => x kişisi ve y,z,k nöbetleri
                    PersonalInformation = key2.Personal.GetIdentityForPdf(),
                    PersonalUnityName = key2.Personal.PersonalUnity.Name,
                    //RankNumber=key2.Personal.Rank.Number
                    DayNumbersAndGuardNumbers = group2.Select(z => z.Date)
                    .GroupBy(t => new { t.DayOfWeek }, (key3, group3) => new DayNumberAndGuardNumbers()
                    {
                        //HAFTANIN GUNLERINE GORE GRUPLANDI VE O GUNE AIT NOBET STRING HALINE GETIRILDI
                        //HAFTANIN GUNLERI VE O GUNE AIT NOBETLER  => ptesi  için 1,8 ; salı için 2 ;çars için 3,10
                        DayNumber = ((int)key3.DayOfWeek).ToString(),
                        GuardNumbers = string.Join(",", group3.Select(g => g.Day.ToString()))
                    }).ToList()
                }).ToList()
              }).ToList();

            return pDFHelperModals;
        }
    }
}
