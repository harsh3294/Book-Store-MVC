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
    public class Store : IStore
    {
        private BookStoreModel db;
        public Store(BookStoreModel db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Store> GetStores()
        {
            return db.Stores
                .Include("Location")
                .ToList();
        }
        public Data.Entities.Store GetStoreById(int id)
        {
            if (id > 0)
            {
                var store = db.Stores.Include("Location")
                    .Where(c => c.Store_Id == id)
                    .FirstOrDefault();
                if (store != null)
                    return store;
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
        public void AddStore(Data.Entities.Store store)
        {
            db.Stores.Add(store);
            save();
        }
        public IEnumerable<Data.Entities.Location> GetLocations()
        {
            return db.Locations
                  .ToList();
        }
        public void UpdateStoreById(int id, Data.Entities.Store store)
        {
            var getStore = db.Stores.Where<Data.Entities.Store>(u => u.Store_Id == id).First();
            if (getStore != null)
            {
                getStore.Location_Id = store.Location_Id;
                getStore.Store_Name = store.Store_Name;
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Store Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void DeleteStoreById(int id)
        {
            var store = db.Stores.Where<Data.Entities.Store>(u => u.Store_Id == id).First();
            if (store != null)
            {
                db.Stores.Remove(store);
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Store Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
