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
    public class Role:IRole
    {
        private BookStoreModel db;
        public Role(BookStoreModel db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Role> GetRoles()
        {
            return db.Roles
                  .ToList();
        }
        public Data.Entities.Role GetRoleById(int id)
        {
            if (id > 0)
            {
                var role = db.Roles
                    .Where(c => c.Role1 == id)
                    .FirstOrDefault();
                if (role != null)
                    return role;
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
        public void AddRole(Data.Entities.Role role)
        {
            db.Roles.Add(role);
            save();
        }
        public void UpdateRoleById(int id, Data.Entities.Role role)
        {
            var getRole = db.Roles.Where<Data.Entities.Role>(u => u.Role1 == id).First();
            if (getRole != null)
            {
                getRole.Role_Name=role.Role_Name;
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Role Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void DeleteRoleById(int id)
        {
            var role = db.Roles.Where<Data.Entities.Role>(u => u.Role1 == id).First();
            if (role != null)
            {
                db.Roles.Remove(role);
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Role Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
