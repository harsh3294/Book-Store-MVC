using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface IRole
    {
        IEnumerable<Data.Entities.Role> GetRoles();
        Data.Entities.Role GetRoleById(int id);
        void AddRole(Data.Entities.Role role);
        void UpdateRoleById(int id, Data.Entities.Role role);
        void DeleteRoleById(int id);
        void save();
    }
}
