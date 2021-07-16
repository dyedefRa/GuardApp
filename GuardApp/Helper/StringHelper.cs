﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}