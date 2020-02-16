using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class Part
    {
        public int PartId { get; set; }
        public string PartName { get; set; }

        public virtual List<Job> Job { get; set; }
        public virtual List<User> User { get; set; }
        public static Entities.Part PartEntities(DAL.Part p)
        {
            return new Entities.Part()
            {
                PartId = p.PartId,
                PartName = p.PartName

            };
        }
        public static DAL.Part PartDAL(Entities.Part p)
        {
            return new DAL.Part()
            {
                PartId = p.PartId,
                PartName = p.PartName

            };
        }
    }
}
