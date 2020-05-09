using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class ŽaidėjaiViewModel
    {
        [DisplayName("Žaidejo_Kodas")]
        public int Zaidejo_Kodas { get; set; }

        [DisplayName("Pavardė")]
        public string Pavarde { get; set; }

        [DisplayName("Amžius")]
        public int Amzius { get; set; }

        [DisplayName("Patirtis")]
        public int Patirtis { get; set; }

        [DisplayName("Vardas")]
        public string Vardas { get; set; }

        [DisplayName("Komandos_ID")]
        public int Komandos_ID { get; set; }
    }
}