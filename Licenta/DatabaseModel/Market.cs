using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class Market
    {
        public int ID { get; set; }
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Nume invalid")]
        public string Denumire { get; set; }
        [Required(ErrorMessage = "Imaginea magazinului este obligatorie")]
        public string Imagine { get; set; }
        public string Oras { get; set; }
        public List<int> Coordonate { get; set; }
    }
}
