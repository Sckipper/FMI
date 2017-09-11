using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseModel
{
    public class SupplierContainer
    {
        public static List<Supplier> GetSuppliers()
        {
            return new ShopAppEntities().Furnizor.Select(el => new Supplier()
            {
                ID = el.ID,
                Nume = el.Nume,
                Adresa = el.Adresa,
                Oras = el.Oras,
                Telefon = (long)el.Telefon

            }).ToList();
        }

        public static List<string> getTopSuppliersCities(int top)
        {
            return new ShopAppEntities().Furnizor.GroupBy(el => el.Oras).Select(grp => grp.Key).Take(top).ToList();
        }

        public static int getNrOfSupplierByCity(string city)
        {
            return new ShopAppEntities().Furnizor.Where(el => el.Oras.Equals(city)).Count();
        }

        public static int getNrOfSuppliers()
        {
            return new ShopAppEntities().Furnizor.Count();
        }

        public static Supplier getSupplierById(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Furnizor supp = db.Furnizor.FirstOrDefault(el => el.ID == id);
                return new Supplier()
                {
                    ID = supp.ID,
                    Nume = supp.Nume,
                    Adresa = supp.Adresa,
                    Oras = supp.Oras,
                    Telefon = (long)supp.Telefon
                };
            }
        }

        public static void SaveSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("Supplier");

            using (var db = new ShopAppEntities())
            {
                Furnizor sup = db.Furnizor.FirstOrDefault(el => el.ID == supplier.ID);
                if (sup == null)
                {
                    sup = new Furnizor();
                    db.Furnizor.Add(sup);
                }

                sup.ID = supplier.ID;
                sup.Nume = supplier.Nume;
                sup.Adresa = supplier.Adresa;
                sup.Oras = supplier.Oras;
                sup.Telefon = supplier.Telefon;

                db.SaveChanges();
            }
        }

        public static void DeleteSupplier(int id)
        {
            if (id < 0)
                throw new ArgumentNullException("Supplier");

            using (var db = new ShopAppEntities())
            {
                Furnizor sup = db.Furnizor.FirstOrDefault(el => el.ID == id);

                if (sup != null)
                {
                    db.Furnizor.Remove(sup);
                    db.SaveChanges();
                }
            }
        }

    }
}
