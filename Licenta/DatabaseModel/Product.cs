using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Product
    {
        public int ID { get; set; }
        public int CategorieID { get; set; }
        public int MagazinID { get; set; }
        public string Denumire { get; set; }
        public string Greutate { get; set; }
        public Nullable<double> Pret { get; set; }
        public int Cantitate { get; set; }
        public Nullable<System.DateTime> DataExpirate { get; set; }
        public string Descriere { get; set; }
        public string Imagine { get; set; }
    }
}
