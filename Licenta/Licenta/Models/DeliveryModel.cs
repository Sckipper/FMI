using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseModel;

namespace Licenta.Models
{
    public class DeliveryModel
    {
        public Delivery Delivery { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Market> Markets { get; set; }
        public List<string> Statuses = new List<string>(new string[] { "Initiata", "Procesare", "Livrata", "Refuzata" });
    }
}