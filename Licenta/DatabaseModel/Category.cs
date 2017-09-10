using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> CategorieID { get; set; }
        [Required(ErrorMessage = "Nume invalid")]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Cod invalid")]
        public string Cod { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
        public List<int> MarketCoords { get; set; }
    }
}
