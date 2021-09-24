using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.Repository
{
    public class Location : ILocation
    {
        private BookStoreModel db;
        public Location(BookStoreModel db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Location> GetLocations()
        {
            return db.Locations
                  .ToList();
        }
        public Data.Entities.Location GetLocationById(int id)
        {
            if (id > 0)
            {
                var location = db.Locations
                    .Where(c => c.Location_Id == id)
                    .FirstOrDefault();
                if (location != null)
                    return location;
                else
                {
                    return null;
                }
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }
        public void AddLocation(Data.Entities.Location location)
        {
            db.Locations.Add(location);
            save();
        }
        public void UpdateLocationById(int id, Data.Entities.Location location)
        {
            var getLocation = db.Locations.Where<Data.Entities.Location>(u => u.Location_Id == id).First();
            if (getLocation != null)
            {
                getLocation.Location_Name = location.Location_Name;
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Location Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void DeleteLocationById(int id)
        {
            var location = db.Locations.Where<Data.Entities.Location>(u => u.Location_Id == id).First();
            if (location != null)
            {
                db.Locations.Remove(location);
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Location Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
