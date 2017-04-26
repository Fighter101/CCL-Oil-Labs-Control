using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class Station
    {

        public static IList<Station> getStations(int companyName , int CompanyType)
        {
            var stationList = new List<Station>();

            using (var model = new DatabaseEntities())
            {
                stationList = (from station in model.Stations
                               where station.CompanyName == companyName &&
                               station.CompanyType == CompanyType
                               select station).ToList();
            }
                return stationList;
        }

        public static IList<Station> getStations(int companyName, int CompanyType,string stationName)
        {
            var stationList = new List<Station>();

            using (var model = new DatabaseEntities())
            {
                stationList = (from station in model.Stations
                               where station.CompanyName == companyName &&
                               station.CompanyType == CompanyType && station.Name == stationName
                               select station).ToList();
            }
            return stationList;
        }


    }
}
