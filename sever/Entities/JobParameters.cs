using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class JobParameters
    {

        public List< Entities.Area> Areas { get; set; }
        public List< Entities.SubjectJob> SubjectJob { get; set; }
        public List< Entities.Part> Parts { get; set; }
        public List<Entities.City> Cities { get; set; }
        public List<Entities.OutNet> OutNets { get; set; }
        public List<Entities.Workspace> Workspaces { get; set; }

    }
}
