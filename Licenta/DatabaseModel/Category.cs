using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Category
    {
        public int ID { get; set; }
        public Nullable<int> CategorieID { get; set; }
        public string Nume { get; set; }
        public string Cod { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
    }
}
