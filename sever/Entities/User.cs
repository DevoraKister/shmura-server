using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities
{
  public  class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public string UserMail { get; set; }
        public Nullable<int> UserCityId { get; set; }
        public Nullable<int> UserSubId { get; set; }
        public Nullable<bool> UserIsChizuk { get; set; }
        public Nullable<bool> UserIsUpdate { get; set; }
        public Nullable<int> UserPartId { get; set; }
        public Nullable<bool> UserIsSmartAgent { get; set; }
        public Nullable<int> UserSmartAgentTime { get; set; }
        public virtual City City { get; set; }
        public virtual Part Part { get; set; }
        public virtual List<PutInJob> PutInJob { get; set; }
        public virtual List<Question> Question { get; set; }
        public virtual List<Recomend> Recomend { get; set; }
        public virtual List<Request> Request { get; set; }
        public virtual List<Sign> Sign { get; set; }
        public virtual SubjectJob SubjectJob { get; set; }
        public JobParameters jobParameters { get; set; }
        public string password { get; set; }
        public string cvURL { get; set; }

        public static Entities.User UserEntities(DAL.User u)
        {
            return new Entities.User()
            {
                UserCityId = u.UserCityId,
                UserId = u.UserId,
                UserIsChizuk = u.UserIsChizuk,
                UserIsUpdate = u.UserIsUpdate,
                UserMail = u.UserMail,
                UserName = u.UserName,
                UserPartId = u.UserPartId,
                UserSubId = u.UserSubId,
                UserTel = u.UserTel
               ,password=u.UserPassword,
                UserIsSmartAgent=u.UserIsSmartAgent,
                UserSmartAgentTime=u.UserSmartAgentTime



    



    };
        }
        public static DAL.User UserDAL(Entities.User u)
        {
            return new DAL.User()
            {
                UserCityId = u.UserCityId,
                UserId = u.UserId,
                UserIsChizuk = u.UserIsChizuk,
                UserIsUpdate = u.UserIsUpdate,
                UserMail = u.UserMail,
                UserName = u.UserName,
                UserPartId = u.UserPartId,
                UserSubId = u.UserSubId,
                UserTel = u.UserTel,
                UserPassword = u.password,
                UserIsSmartAgent = u.UserIsSmartAgent,
                UserSmartAgentTime = u.UserSmartAgentTime


            };
        }
    }
}
