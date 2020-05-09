using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class TwoArenas 
    {
        [DisplayName("newArenasArray")]
        public List<ArenaEditViewModel> newArenasArray { get; set; }
    }
}