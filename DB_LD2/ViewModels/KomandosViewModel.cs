using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class KomandosViewModel
    {
        [DisplayName("Komandos_ID")]
        public int Komandos_ID { get; set; }
        [DisplayName("Komandos_Pav")]
        public string Komandos_Pav { get; set; }
        [DisplayName("Miestas")]
        public string Miestas { get; set; }
        [DisplayName("Valstija")]
        public string Valstija { get; set; }
        [DisplayName("Divizionas")]
        public int Divizionas { get; set; }
    }
}