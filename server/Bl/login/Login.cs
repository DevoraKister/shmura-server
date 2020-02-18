using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.login
{
    public class Login
    {

        public static bool CheckIsLogin(Entities.User u)
        {
            List<Entities.User> user = new List<Entities.User>();
            var x = user.FirstOrDefault(c => c.UserName == u.UserName && c.password == u.password);
            if (x == null)
                return false;
            return true;
        }
     //public static Entities.User Register(string UserName, bool UserIsChizuk, bool UserIsUpdate, string UserPart, string UserTel, string password,
     //      string UserSub, string UserMail, string UserCity)


     //   {
     //       Entities.User NewUser = new Entities.User();
     //       NewUser.UserMail = UserMail;
     //   }
        //=====================================מחזיר עיר ID============================
        public static int CityId(string City)
        {
            List<Entities.City> city = new List<Entities.City>();
            var x = city.FirstOrDefault(c => c.CityName.Equals ( City)).CityId;
            if (x == null)
                return 0;
            return x;

        }
        //==================================תחום מחזיר ID ========================
        public static int SubId(string SubId)
        {
            var x = 0;
            List<Entities.SubjectJob> subject = new List<Entities.SubjectJob>();
            x = subject.FirstOrDefault(c => c.SubName.Equals(SubId)).SubId;

            return x;
        }
        //=======================================אזור ID  מחזיר ==========================
        public static int? AreaId(string City)
        {
            int? x = 0;
            List<Entities.City> area = new List<Entities.City>();
           x = area.FirstOrDefault(c => c.CityName.Equals(City)).CityAreaId;
            return x;
        }
        //-----בשביל משתמש חדש בודק האם סיסמא קיימת כבר
        public static bool NotValidPassword(string pw)
        {
            List<Entities.Boss> boss = new List<Entities.Boss>();
            List<Entities.User> user = new List<Entities.User>();
            var x = boss.FirstOrDefault(e => e.BossPassword.Equals(pw));
            if (x != null)
                return false;
            var y = user.FirstOrDefault(e => e.password.Equals(pw));
            if (y != null)
                return false;
            return true;

        }
        //--------------בודק אם שם וסיסמא נכונים בכניסת מנהל/מציע משרה
        public static bool IsRegistered(string name, string pw)
        {
            List<Entities.Boss> boss = new List<Entities.Boss>();
            var x = boss.Find(p => p.BossPassword.Equals(pw) && p.BossName.Equals(name));
            if (x != null)
                return true;
            return false;

        }

    }


}

