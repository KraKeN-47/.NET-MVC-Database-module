using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class TeisejaiViewModel
    {
        [DisplayName("Vardas")]
        public string Vardas { get; set; }
        [DisplayName("Pavarde")]
        public string Pavarde { get; set; }
        [DisplayName("Amzius")]
        public int Amzius { get; set; }
        [DisplayName("Patirtis")]
        public int Patirtis { get; set; }
        [DisplayName("Asmens_Kodas")]
        public int Asmens_Kodas { get; set; }

    }
}