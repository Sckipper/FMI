using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class CategoryContainer
    {
        public List<Category> GetCategories()
        {
            return new ShopAppEntities().Categorie.Select(el => new Category()
            {
                ID = el.ID,
                CategorieID = el.CategorieID,
                Nume = el.Nume,
                Cod = el.Cod,
                Descriere = el.Descriere,
                Imagine = el.Imagine
            }).ToList();
        }

        public static void SaveCategory(Categorie category)
        {
            if (category == null)
                throw new ArgumentNullException("Category");

            using (var db = new ShopAppEntities())
            {
                Categorie categ = db.Categorie.FirstOrDefault(el => el.ID == category.ID);
                if (categ == null)
                {
                    categ = new Categorie();
                    db.Categorie.Add(categ);
                }

                categ.CategorieID = category.CategorieID;
                categ.Nume = category.Nume;
                categ.Cod = category.Cod;
                categ.Descriere = category.Descriere;
                categ.Imagine = category.Imagine;

                db.SaveChanges();
            }
        }

        public static void DeleteCategory(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Categorie categ = db.Categorie.FirstOrDefault(el => el.ID == id);
                if (categ != null)
                {
                    db.Categorie.Remove(categ);
                    db.SaveChanges();
                }
            }
        }

    }
}
