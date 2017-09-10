using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class DeliveryContainer
    {
        public static List<Delivery> GetDeliveries()
        {
            return new ShopAppEntities().Livrare.Select(el => new Delivery()
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

        public static int getNrOfPendingDeliveries()
        {
            return new ShopAppEntities().Livrare.Where(el => el.Status.Equals("Procesare")) .Count();
        }

        public static int getNrOfInitiatedDeliveries()
        {
            return new ShopAppEntities().Livrare.Where(el => el.Status.Equals("Initiata")).Count();
        }

        public static int getNrOfDeliveredDeliveries()
        {
            return new ShopAppEntities().Livrare.Where(el => el.Status.Equals("Livrata")).Count();
        }

        public static int getNrOfRefusedDeliveries()
        {
            return new ShopAppEntities().Livrare.Where(el => el.Status.Equals("Refuzata")).Count();
        }

        public static Delivery getDeliveryById(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Livrare del = db.Livrare.FirstOrDefault(el => el.ID == id);
                return new Delivery()
                {
                    ID = del.ID,
                    FurnizorID = del.FurnizorID,
                    MagazinID = del.MagazinID,
                    DataSolicitare = del.DataSolicitare,
                    DataLivrare = del.DataLivrare,
                    Status = del.Status,
                    Descriere = del.Descriere,
                    Pret = del.Pret
                };
            }
        }

        public static void SaveDelivery(Delivery delivery)
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

        public static void DeleteDelivery(int id)
        {
            using (var db = new ShopAppEntities())
            {
                Livrare liv = db.Livrare.FirstOrDefault(el => el.ID == id);
                if (liv != null)
                {
                    db.Livrare.Remove(liv);
                    db.SaveChanges();
                }
            }
        }

    }
}
