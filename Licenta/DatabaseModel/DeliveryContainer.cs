using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class DeliveryContainer
    {
        public List<Livrare> GetDeliveries()
        {
            return new ShopAppEntities().Livrare.Select(el => new Livrare()
            {
                ID = el.ID,
                FurnizorID = el.FurnizorID,
                MagazinID = el.MagazinID,
                DataSolicitare = el.DataSolicitare,
                DataLivrare = el.DataLivrare,
                Status = el.Status,
                Descriere = el.Descriere,
                Pret = el.Pret

            }).ToList();
        }

        public static void SaveDelivery(Livrare delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("Delivery");

            using (var db = new ShopAppEntities())
            {
                Livrare liv = db.Livrare.FirstOrDefault(el => el.ID == delivery.ID);
                if (liv == null)
                {
                    liv = new Livrare();
                    db.Livrare.Add(liv);
                }

                liv.FurnizorID = delivery.FurnizorID;
                liv.MagazinID = delivery.MagazinID;
                liv.DataSolicitare = delivery.DataSolicitare;
                liv.DataLivrare = delivery.DataLivrare;
                liv.Status = delivery.Status;
                liv.Descriere = delivery.Descriere;
                liv.Pret = delivery.Pret;

                db.SaveChanges();
            }
        }

        public static void DeleteDelivery(Livrare delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("Delivery");

            using (var db = new ShopAppEntities())
            {
                Livrare liv = db.Livrare.FirstOrDefault(el => el.ID == delivery.ID);
                if (liv != null)
                {
                    db.Livrare.Remove(liv);
                    db.SaveChanges();
                }
            }
        }

    }
}
