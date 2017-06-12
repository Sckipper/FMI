using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Delivery
    {
        public int ID { get; set; }
        public int FurnizorID { get; set; }
        public int MagazinID { get; set; }
        public System.DateTime DataSolicitare { get; set; }
        public Nullable<System.DateTime> DataLivrare { get; set; }
        public string Status { get; set; }
        public string Descriere { get; set; }
        public int Pret { get; set; }
    }
}
