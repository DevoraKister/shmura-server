using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Area
    {
         public int AreaId { get; set; }
        public string AreaName { get; set; }
        public static Entities.Area AreaEntities(DAL.Area a)
        {
            return new Entities.Area()
            {
                AreaId = a.AreaId,
                AreaName = a.AreaName

            };
        }
        public static DAL.Area AreaDAL(Entities.Area a)
        {
            return new DAL.Area()
            {
                AreaId = a.AreaId,
                AreaName = a.AreaName

            };
        }
    }
}
