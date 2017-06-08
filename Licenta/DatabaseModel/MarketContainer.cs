using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class MarketContainer
    {
        public List<Magazin> GetMarkets()
        {
            return new ShopAppEntities().Magazin.Select(el => new Magazin()
            {
                ID = el.ID,
                Adresa = el.Adresa,
                Denumire = el.Denumire,
                Imagine = el.Imagine,
                Oras = el.Oras

            }).ToList();
        }

        public static void SaveMarket(Magazin market)
        {
            if (market == null)
                throw new ArgumentNullException("Market");

            using (var db = new ShopAppEntities())
            {
                Magazin mag = db.Magazin.FirstOrDefault(el => el.ID == market.ID);
                if (mag == null)
                {
                    mag = new Magazin();
                    db.Magazin.Add(mag);
                }

                mag.Adresa = market.Adresa;
                mag.Denumire = market.Denumire;
                mag.Imagine = market.Imagine;
                mag.Oras = market.Oras;

                db.SaveChanges();
            }
        }

        public static void DeleteMatket(Magazin market)
        {
            if (market == null)
                throw new ArgumentNullException("Market");

            using (var db = new ShopAppEntities())
            {
                Magazin mag = db.Magazin.FirstOrDefault(el => el.ID == market.ID);
                if (mag != null)
                {
                    db.Magazin.Remove(mag);
                    db.SaveChanges();
                }
            }
        }

    }
}
