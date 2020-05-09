using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class ArenaViewModel
    {
        [DisplayName("ID")]
        public int Miesto_ID { get; set; }
        [DisplayName("Adresas")]
        public string Adresas { get; set; }
        [DisplayName("Talpa")]
        public int Talpa { get; set; }
        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }
        [DisplayName("Miestas")]
        public string Miestas { get; set; }
    }
}