using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DB_LD2.ViewModels
{
    public class DivizionasViewModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}