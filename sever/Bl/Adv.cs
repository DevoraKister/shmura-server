using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Adv
    {
        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();

        public static List<Entities.Advs> getAdvs()
        {
            List<Entities.Advs> advs = new List<Entities.Advs>();
            foreach (var item in db.Adv.ToList())
            {
                advs.Add(Entities.Advs.AdvsEntities(item));
            }
            return advs;
        }

        public static List<Entities.Advs> removeAdv(int idAdv)
        {
          var a=  db.Adv.FirstOrDefault(p => p.AdvId == idAdv);
            db.Adv.Remove(a);
            db.SaveChanges();
            return getAdvs();
        }
        
    }
}
