using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class UserManager
    {
        public static Angajat GetEmployee(string email, string password)
        {
            return new ShopAppEntities().Angajat.Where(el => (el.Email == email) && (el.Parola == password)).Select(el => new Angajat()
            {
                ID = el.ID,
                MagazinID = el.MagazinID,
                Nume = el.Nume,
                Prenume = el.Prenume,
                CNP = el.CNP,
                Email = el.Email,
                Parola = el.Parola,
                DataAngajare = el.DataAngajare,
                Salariu = el.Salariu,
                Functie = el.Functie
            }).FirstOrDefault();
        }

        public static User AuthentificateUser(string email, string password, bool remember)
        {
            Angajat employee = GetEmployee(email, password);

            if (employee != null)
            {
                var user = new User();
                user.ID = employee.ID;
                user.Nume = employee.Nume;
                user.Prenume = employee.Prenume;
                user.Email = employee.Email;
                user.Functie = employee.Functie;

                return user;
            }
            else return null;
        }
    }
}
