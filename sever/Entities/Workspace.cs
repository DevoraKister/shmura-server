using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Workspace
    {
        public int WSId { get; set; }
        public string WSName { get; set; }
        public virtual List<Job> Job { get; set; }
        public static Entities.Workspace WorkspaceEntities(DAL.Workspace w)
        {
            return new Entities.Workspace()
            {
                WSId = w.WSId,
                WSName = w.WSName

            };
        }
        public static DAL.Workspace WorkspaceDAL(Entities.Workspace w)
        {
            return new DAL.Workspace()
            {
                WSId = w.WSId,
                WSName = w.WSName

            };
        }
    }
}
