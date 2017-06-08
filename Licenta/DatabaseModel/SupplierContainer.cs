using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class SupplierContainer
    {
        public List<Furnizor> GetSuppliers()
        {
            return new ShopAppEntities().Furnizor.Select(el => new Furnizor()
            {
                ID = el.ID,
                Nume = el.Nume,
                Adresa = el.Adresa,
                Oras = el.Oras,
                Telefon = el.Telefon

            }).ToList();
        }

        public static void SaveSupplier(Furnizor supplier)
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

        public static void DeleteDelivery(Furnizor supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("Supplier");

            using (var db = new ShopAppEntities())
            {
                Furnizor sup = db.Furnizor.FirstOrDefault(el => el.ID == supplier.ID);
                if (sup != null)
                {
                    db.Furnizor.Remove(sup);
                    db.SaveChanges();
                }
            }
        }

    }
}
