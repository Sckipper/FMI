using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Employee
    {
        public int ID { get; set; }
        public int MagazinID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public decimal CNP { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public System.DateTime DataAngajare { get; set; }
        public int Salariu { get; set; }
        public string Functie { get; set; }
    }
}
