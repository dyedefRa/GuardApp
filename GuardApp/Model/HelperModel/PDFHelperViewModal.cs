using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardApp.Model.HelperModel
{
    public class PDFHelperViewModal
    {
        public int PersonalId { get; set; }
        public string GuardName { get; set; }
        public int GuardNumber { get; set; }
        public string PersonalInformation { get; set; }
        public List<int> GuardDayOnMonth { get; set; }
        public string UnityName { get; set; }
    }
}
