using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Magazin invalid")]
        public int MagazinID { get; set; }
        public string MarketName { get; set; }
        [Required(ErrorMessage = "Nume obligatoriu")]
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Required(ErrorMessage = "CNP invalid")]
        public decimal CNP { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola obligatorie")]
        public string Parola { get; set; }
        [Required(ErrorMessage = "Data invalida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DataAngajare { get; set; }
        [Required(ErrorMessage = "Salariu obligatoriu")]
        public int Salariu { get; set; }
        public string Functie { get; set; }
    }
}
