using GuardApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Helper
{
   public static class SingletonDb
    {
        public static Context Context = new Context();
    }
}
