using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    interface ILocation
    {
        IEnumerable<Data.Entities.Location> GetLocations();
        Data.Entities.Location GetLocationById(int id);
        void AddLocation(Data.Entities.Location location);
        void UpdateLocationById(int id, Data.Entities.Location location);
        void DeleteLocationById(int id);
        void save();
    }
}
