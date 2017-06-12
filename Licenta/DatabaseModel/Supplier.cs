using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string Oras { get; set; }
        public decimal Telefon { get; set; }
    }
}
