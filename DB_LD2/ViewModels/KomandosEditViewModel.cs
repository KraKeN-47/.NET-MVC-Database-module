using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_LD2.ViewModels
{
    public class KomandosEditViewModel
    {
        [DisplayName("Komandos_ID")]
        [Required]
        public int Komandos_ID { get; set; }

        [DisplayName("Komandos_Pav")]
        [Required]
        public string Komandos_Pav { get; set; }

        [DisplayName("Miestas")]
        [Required]
        public string Miestas { get; set; }

        [DisplayName("Valstija")]
        [Required]
        public string Valstija { get; set; }

        [DisplayName("Divizionas")]
        [Required]
        [Range(1,6)]
        public int Divizionas { get; set; }

        public IList<SelectListItem> Divizionai { get; set; }
    }
}