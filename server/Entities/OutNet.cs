using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OutNet
    {
        public int OutNetId { get; set; }
        public string OutNetName { get; set; }

        public virtual List<Job> Job { get; set; }
        public static Entities.OutNet OutNetEntities(DAL.OutNet o)
        {
            return new Entities.OutNet()
            {
                OutNetId = o.OutNetId,
                OutNetName = o.OutNetName

            };
        }
        public static DAL.OutNet OutNetDAL(Entities.OutNet o)
        {
            return new DAL.OutNet()
            {
                OutNetId = o.OutNetId,
                OutNetName = o.OutNetName

            };
        }
    }
}
