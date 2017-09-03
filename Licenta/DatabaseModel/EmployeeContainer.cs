using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class EmployeeContainer
    {
        public static List<Employee> GetEmployees()
        {
            return new ShopAppEntities().Angajat.Select(el => new Employee()
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

        public static Employee getEmployeeById(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Angajat ang = db.Angajat.FirstOrDefault(el => el.ID == id);
                return new Employee()
                {
                    ID = ang.ID,
                    MagazinID = ang.MagazinID,
                    Nume = ang.Nume,
                    Prenume = ang.Prenume,
                    CNP = ang.CNP,
                    Email = ang.Email,
                    Parola = ang.Parola,
                    DataAngajare = ang.DataAngajare,
                    Salariu = ang.Salariu,
                    Functie = ang.Functie
                };
            }
        }

        public static void SaveEmployee(Employee employee)
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

        public static void DeleteEmployee(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Employee");

            using (var db = new ShopAppEntities())
            {
                Angajat ang = db.Angajat.FirstOrDefault(el => el.ID == id);
                if (ang != null)
                {
                    db.Angajat.Remove(ang);
                    db.SaveChanges();
                }
            }
        }

    }
}
