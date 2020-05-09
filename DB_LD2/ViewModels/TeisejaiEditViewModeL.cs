using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class TeisejaiEditViewModeL
    {
        [DisplayName("Vardas")]
        [Required]
        public string Vardas { get; set; }

        [DisplayName("Pavarde")]
        [Required]
        public string Pavarde { get; set; }

        [DisplayName("Amzius")]
        [Required]
        public int Amzius { get; set; }

        [DisplayName("Patirtis")]
        [Required]
        public int Patirtis { get; set; }

        [DisplayName("Asmens_Kodas")]
        [Required]
        public int Asmens_Kodas { get; set; }
    }
}