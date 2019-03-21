using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework
{
    class Territorio
    {
        private NorthwindEntities entities = new NorthwindEntities();

        public List<Territory> GetTerritories()
        {
            return entities.Territories.ToList();
        }

        public Territory GetTerritoryById(String id)
        {
            return entities.Territories.FirstOrDefault(t => t.TerritoryID == id);
        }

        public void UpdateTerritory(Territory newTerritory)
        {
            var territory = GetTerritoryById(newTerritory.TerritoryID);
            if (territory != null)
            {
                territory.TerritoryDescription = newTerritory.TerritoryDescription;
                territory.RegionID = newTerritory.RegionID;
                entities.SaveChanges();
            }
        }

        public void CreateTerritory(Territory territory)
        {
            entities.Territories.Add(territory);
            entities.SaveChanges();
        }

        public void DeleteTerritory(String id)
        {
            var territory = GetTerritoryById(id);
            if(territory != null)
            {
                entities.Territories.Remove(territory);
                entities.SaveChanges();
            }
        }
    }
}
