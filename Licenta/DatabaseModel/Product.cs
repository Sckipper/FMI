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
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Categorie invalida")]
        public int CategorieID { get; set; }
        public string MarketName { get; set; }
        [Required(ErrorMessage = "Magazin invalid")]
        public int MagazinID { get; set; }
        [Required(ErrorMessage = "Denumire invalida")]
        public string Denumire { get; set; }
        public string Greutate { get; set; }
        public Nullable<double> Pret { get; set; }
        [Required(ErrorMessage = "Cantitate invalida")]
        public int Cantitate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public Nullable<System.DateTime> DataExpirate { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
    }
}
