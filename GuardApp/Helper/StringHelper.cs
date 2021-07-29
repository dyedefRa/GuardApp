using GuardApp.Model;
using GuardApp.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GuardApp.Helper
{
    public static class StringHelper
    {
        private static CultureInfo trCulture = new CultureInfo("tr-TR");

        public static string TurkishDateTimeShortToString(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM, yyyy", trCulture);
        }

        public static string TurkishDateTimeLongToString(this DateTime dateTime)
        {
            return dateTime.ToString("dd MMMM, yyyy", trCulture);
        }

        public static string PDFDocumentFolderPathToString(this DateTime dateTime,string localStorageName="D")
        {
            return localStorageName + ":/NTP_" + dateTime.Month.ToString() + "_" + dateTime.Year.ToString() + ".pdf";         
        }

        public static List<PersonalViewModal> PersonalDisplayerFormatList(this List<Personal> personals)
        {
            return personals.Select(x => new PersonalViewModal()
            {
                PersonalId = x.Id,
                Name = x.Rank.Name + " " + x.Name + " " + "( " + x.PersonalUnity.Name + " )"
            }).ToList();
        }
    }
}
