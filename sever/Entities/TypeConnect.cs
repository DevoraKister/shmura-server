using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class TypeConnect
    {
        public int TypeConnectId { get; set; }
        public string TypeConnectName { get; set; }

        public virtual List<Request> Request { get; set; }
        public static Entities.TypeConnect TypeConnectEntities(DAL.TypeConnect t)
        {
            return new Entities.TypeConnect()
            {
                TypeConnectId = t.TypeConnectId,
                TypeConnectName = t.TypeConnectName
            };
        }
        public static DAL.TypeConnect TypeConnectDAL(Entities.TypeConnect t)
        {
            return new DAL.TypeConnect()
            {
                TypeConnectId = t.TypeConnectId,
                TypeConnectName = t.TypeConnectName
            };
        }
    }
}
