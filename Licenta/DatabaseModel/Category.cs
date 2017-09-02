using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Category
    {
        public int ID { get; set; }
        public Nullable<int> CategorieID { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Cod { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
    }
}
