using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data.Repository
{
    interface IUser
    {
        IEnumerable<Data.Entities.User> GetUsers();
        Data.Entities.User GetUserById(int id);
        void AddUser(Data.Entities.User user);
        void UpdateUserById(int id,Data.Entities.User user);
        void DeleteUserById(int id);
        void save();
    }
}
