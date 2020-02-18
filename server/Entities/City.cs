using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Nullable<int> CityAreaId { get; set; }
        public static Entities.City CityEntities(DAL.City c)
        {
            return new Entities.City()
            {
                CityAreaId = c.CityAreaId,
                CityId = c.CityId,
                CityName = c.CityName
            };
        }
        public static DAL.City CityDAL(Entities.City c)
        {
            return new DAL.City()
            {
                CityAreaId = c.CityAreaId,
                CityId = c.CityId,
                CityName = c.CityName
            };
        }

    }
}
