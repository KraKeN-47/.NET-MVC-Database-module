using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_LD2.ViewModels
{
    public class ŽaidėjaiEditViewModel
    {
        [DisplayName("Žaidejo_Kodas")]
        [Required]
        public int Zaidejo_Kodas { get; set; }

        [DisplayName("Pavardė")]
        [Required]
        public string Pavarde { get; set; }

        [DisplayName("Amžius")]
        [Required]
        public int Amzius { get; set; }

        [DisplayName("Patirtis")]
        [Required]
        public int Patirtis { get; set; }

        [DisplayName("Vardas")]
        [Required]
        public string Vardas { get; set; }

        [DisplayName("Komandos_ID")]
        [Required]
        public int Komandos_ID { get; set; }

        public IList<SelectListItem> Komandu_ID { get; set; }
    }
}