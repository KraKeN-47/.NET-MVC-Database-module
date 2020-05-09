using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class ArenaEditViewModel
    {
        [DisplayName("ID")]
        [Required]
        public int Miesto_ID { get; set; }

        [DisplayName("Adresas")]
        [Required]
        public string Adresas { get; set; }

        [DisplayName("Talpa")]
        [Required]
        public int Talpa { get; set; }
        
        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }

        [DisplayName("Miestas")]
        [Required]
        public string Miestas { get; set; }
    }
}