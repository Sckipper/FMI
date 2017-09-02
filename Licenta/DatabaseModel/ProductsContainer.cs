﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class ProductsContainer
    {
        public List<Product> GetProducts()
        {
            return new ShopAppEntities().Produs.Select(el => new Product()
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
                Imagine = el.Imagine
            }).ToList();
        }

        public static Product getProductById(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Produs prod = db.Produs.FirstOrDefault(el => el.ID == id);
                return new Product()
                {
                    ID = prod.ID,
                    CategorieID = prod.CategorieID,
                    MagazinID = prod.MagazinID,
                    Denumire = prod.Denumire,
                    Greutate = prod.Greutate,
                    Pret = prod.Pret,
                    Cantitate = prod.Cantitate,
                    DataExpirate = prod.DataExpirate,
                    Descriere = prod.Descriere,
                };
            }

        }

        public static void SaveProduct(Product product)
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

        public static void DeleteProduct(Product product)
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
