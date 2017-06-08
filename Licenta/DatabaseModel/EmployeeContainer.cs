using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class EmployeeContainer
    {
        public List<Angajat> GetEmployees()
        {
            return new ShopAppEntities().Angajat.Select(el => new Angajat()
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
                
            }).ToList();
        }

        public static void SaveEmployees(Angajat employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee");

            using (var db = new ShopAppEntities())
            {
                Angajat ang = db.Angajat.FirstOrDefault(el => el.ID == employee.ID);
                if (ang == null)
                {
                    ang = new Angajat();
                    db.Angajat.Add(ang);
                }

                ang.MagazinID = employee.MagazinID;
                ang.Nume = employee.Nume;
                ang.Prenume = employee.Prenume;
                ang.CNP = employee.CNP;
                ang.Email = employee.Email;
                ang.Parola = employee.Parola;
                ang.DataAngajare = employee.DataAngajare;
                ang.Salariu = employee.Salariu;
                ang.Functie = employee.Functie;

                db.SaveChanges();
            }
        }

        public static void DeleteProduct(Angajat employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee");

            using (var db = new ShopAppEntities())
            {
                Angajat ang = db.Angajat.FirstOrDefault(el => el.ID == employee.ID);
                if (ang != null)
                {
                    db.Angajat.Remove(ang);
                    db.SaveChanges();
                }
            }
        }

    }
}
