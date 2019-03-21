using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework
{
    class ShipperCRUD
    {
        private NorthwindEntities entities = new NorthwindEntities();

        public List<Shipper> GetShippers()
        {
            return entities.Shippers.ToList();
        }

        public Shipper GetShipperByID(int id)
        {
            return entities.Shippers.FirstOrDefault(c => c.ShipperID == id);
        }

        public void UpdateShipper(Shipper newShipper)
        {
            var shipper = GetShipperByID(newShipper.ShipperID);
            if(shipper != null)
            {
                shipper.CompanyName = newShipper.CompanyName;
                shipper.Phone = newShipper.Phone;

                entities.SaveChanges();
            }
        }

        public void CreateShipper(Shipper shipper)
        {
            entities.Shippers.Add(shipper);
            entities.SaveChanges();
        }
        
        public void DeleteShipper(int id)
        {
            var shipper = GetShipperByID(id);
            if(shipper != null)
            {
                entities.Shippers.Remove(shipper);
                entities.SaveChanges();
            }
        }
    }
}
