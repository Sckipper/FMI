using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public int CategorieID { get; set; }
        [Required]
        public int MagazinID { get; set; }
        [Required]
        public string Denumire { get; set; }
        public string Greutate { get; set; }
        public Nullable<double> Pret { get; set; }
        [Required]
        public int Cantitate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> DataExpirate { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
    }
}
