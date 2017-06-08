using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class ProductsContainer
    {
        public List<Produs> GetProducts()
        {
            return new ShopAppEntities().Produs.Select(el => new Produs()
            {
                ID = el.ID,
                CategorieID = el.CategorieID,
                MagazinID = el.MagazinID,
                Denumire = el.Denumire,
                Greutate = el.Greutate,
                Pret = el.Pret,
                Cantitate = el.Cantitate,
                DataExpirate = el.DataExpirate,
                Descriere = el.Descriere,
            }).ToList();
        }

        public static void SaveProduct(Produs product)
        {
            if (product == null)
                throw new ArgumentNullException("Product");

            using (var db = new ShopAppEntities())
            {
                Produs prod = db.Produs.FirstOrDefault(el => el.ID == product.ID);
                if (prod == null)
                {
                    prod = new Produs();
                    db.Produs.Add(prod);
                }

                prod.CategorieID = product.CategorieID;
                prod.MagazinID = product.MagazinID;
                prod.Denumire = product.Denumire;
                prod.Greutate = product.Greutate;
                prod.Pret = product.Pret;
                prod.Cantitate = product.Cantitate;
                prod.DataExpirate = product.DataExpirate;
                prod.Descriere = product.Descriere;

                db.SaveChanges();
            }
        }

        public static void DeleteProduct(Produs product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            using (var db = new ShopAppEntities())
            {
                Produs prod = db.Produs.FirstOrDefault(el => el.ID == product.ID);
                if (prod != null)
                {
                    db.Produs.Remove(prod);
                    db.SaveChanges();
                }
            }
        }

    }
}
