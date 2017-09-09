using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class Supplier
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nume invalid")]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Adresa invalida")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Oras invalid")]
        public string Oras { get; set; }
        [Required(ErrorMessage = "Telefon invalida")]
        public long Telefon { get; set; }
    }
}
