﻿using System.ComponentModel;

namespace GuardApp.Model.HelperModel
{
    public class GuardSelectionHelperModal
    {
        public int GuardId { get; set; }
        [DisplayName("Nöbet Adı")]
        public string Name { get; set; }
        [DisplayName("Tamamlandı Mı?")]
        public bool IsFullSelectedGuardForNextMonth { get; set; }
    }
}
