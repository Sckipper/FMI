using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class MarketContainer
    {
        public static List<Market> GetMarkets()
        {
            return new ShopAppEntities().Magazin.Select(el => new Market()
            {
                ID = el.ID,
                Adresa = el.Adresa,
                Denumire = el.Denumire,
                Imagine = el.Imagine,
                Oras = el.Oras

            }).ToList();
        }

        public static Market getMarketById(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Magazin mag = db.Magazin.FirstOrDefault(el => el.ID == id);
                return new Market()
                {
                    ID = mag.ID,
                    Adresa = mag.Adresa,
                    Denumire = mag.Denumire,
                    Imagine = mag.Imagine,
                    Oras = mag.Oras
                };
            }
        }

        public static void SaveMarket(Market market)
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

        public static void DeleteMatket(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Market");

            using (var db = new ShopAppEntities())
            {
                Magazin mag = db.Magazin.FirstOrDefault(el => el.ID == id);
                if (mag != null)
                {
                    db.Magazin.Remove(mag);
                    db.SaveChanges();
                }
            }
        }

    }
}
