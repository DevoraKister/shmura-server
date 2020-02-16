using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bl;
using BL.Models;
using Entities;

namespace BL
{

    public static class UserLogic
    {
        public static DAL.IdialEntities3 DB = new DAL.IdialEntities3();
        public static List<DAL.Boss> BossList = new List<DAL.Boss>();
        //בודק אם יוזר קיים
        public static Entities.User CheckIsLogin(Entities.User u)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();

                var user = DB.User.ToList();
                var x = user.FirstOrDefault(c => c.UserMail == u.UserMail && c.UserPassword == u.password);
                if (x == null)
                    return null;
                return Entities.User.UserEntities(x);

            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        //בודק אם בוס קיים
        public static Entities.Boss IsRegistered(Entities.Boss b)
        {
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                // List<Entities.Boss> boss2 = new List<Entities.Boss>();
                var boss = DB.Boss.FirstOrDefault(p => p.BossPassword == b.BossPassword && p.BossMail == b.BossMail);

                if (boss != null)
                {

                    return Entities.Boss.BossEntities(boss);
                }

                return null;
            }

        }
        public static bool LogoutBoss()
        {
           
            return true;
        }

        public static Entities.Boss GetBoss(int id)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var boss = DB.Boss.FirstOrDefault(p => p.BossId == id);

                return Entities.Boss.BossEntities(boss);
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static async Task<User> GetUserAsync(User u, Uri requestUri)
        {
            var user = DB.User.FirstOrDefault(p => p.UserMail == u.UserMail && p.UserPassword == u.password);
            if (user != null)//אם המשתמש קיים במאגר המשך לקבלת טוקן, אחרת החזר שגיאה שהמתשמש לא קיים
            {
                var accessToken = await GetTokenDataAsync(user.UserName, user.UserPassword, requestUri);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    return new WebResult<LoginData>
                    {
                        Success = true,
                        Message = "התחברת בהצלחה",
                        Value = new LoginData
                        {
                            TokenJson = accessToken,
                            User = Entities.User.UserEntities(user)
                        }
                    };
                }
            };
            return null;
        }


        private static async Task<string> GetTokenDataAsync(string username, string password, Uri req)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(req.Scheme + "://" + req.Authority + "/token");
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("UserName", username));
            postData.Add(new KeyValuePair<string, string>("Password", password));
            postData.Add(new KeyValuePair<string, string>("grant_type", "password"));//don't dare to change that!!!
            HttpContent content = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = await httpClient.PostAsync("token", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static User GetUser(int id)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var user = DB.User.FirstOrDefault(p => p.UserId == id);
                return User.UserEntities(user);
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }


        //-----בשביל משתמש חדש בודק האם המייל קיים כבר
        public static bool NotValidPasswordUser(string mail)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var user = DB.User.ToList();
                var y = user.FirstOrDefault(e => e.UserMail == mail);
                if (y != null)
                    return false;
                return true;
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }

        }
        //-----בשביל מפרסם חדש בודק האם המייל קיים כבר
        public static bool NotValidPasswordBoss(string mail)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var boss = DB.Boss.ToList();
                var x = boss.FirstOrDefault(e => e.BossMail == mail);
                if (x != null)

                    return false;
                return true;
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }

        }
        //רושם בוס חדש
        //public static void registerBoss(Entities.Boss boss)
        //{
        //    DB.Boss.Add(Entities.Boss.BossDAL(boss));
        //    DB.SaveChanges();
        //}
        //public static void registerUser(Entities.User user)
        //{

        //    DB.User.Add(Entities.User.UserDAL(user));
        //    DB.SaveChanges();
        //}

        public static Entities.Boss registerBoss(Entities.Boss boss)
        {
            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    DB.Boss.Add(Entities.Boss.BossDAL(boss));
                    DB.SaveChanges();


                    var u = DB.Boss.FirstOrDefault(x => x.BossMail == boss.BossMail && x.BossPassword == boss.BossPassword);

                    //BL.SendMail.SendEmail(data, "ברוך בואך לאתר אידיאל", u.UserMail);
                    //var p = BL.SendMail.register(u.BossName, u.BossPassword, u.BossMail);

                    return Entities.Boss.BossEntities(u);
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }



        public static Entities.User registerUser(Entities.User user)
        {


            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    DB.User.Add(Entities.User.UserDAL(user));
                    DB.SaveChanges();

                    var u = DB.User.FirstOrDefault(x => x.UserMail == user.UserMail && x.UserPassword == user.password);

                    //BL.SendMail.SendEmail(data, "ברוך בואך לאתר אידיאל", u.UserMail);
                    //var p = BL.SendMail.register(u.UserName, u.UserPassword, u.UserMail);

                    return Entities.User.UserEntities(u);
                }
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        public static HttpResponseMessage addCv(string mail)
        {


            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    string s = mail.Substring(0, mail.LastIndexOf('.'));
                    var cvUserId = DB.User.FirstOrDefault(d => d.UserMail == s).UserId;
                    var check = DB.Cv.FirstOrDefault(a => a.CvUserId == cvUserId);
                    if (check != null)
                        check.CvLink = mail;
                    else
                    {
                        Entities.Cv cv = new Entities.Cv();
                        cv.CvLink = mail;
                        cv.CvUserId = cvUserId;
                        DB.Cv.Add(Entities.Cv.CvDAL(cv));
                    }

                    DB.SaveChanges();

                    return new HttpResponseMessage(HttpStatusCode.OK) { };
                }
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }




        public static Entities.User  EditDetailsUser(Entities.User editUser)
        {
            Entities.User user=new Entities.User();
            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    var y = from u in DB.User
                            where u.UserId == editUser.UserId
                            select u;
                    foreach (var item in y)
                    {
                        item.UserName = editUser.UserName;
                        item.UserPartId = editUser.UserPartId;
                        item.UserPassword = editUser.password;
                        item.UserSubId = editUser.UserSubId;
                        item.UserCityId = editUser.UserCityId;
                        item.UserSubId = editUser.UserSubId;
                        item.UserIsUpdate = editUser.UserIsUpdate;
                        item.UserIsChizuk = editUser.UserIsChizuk;
                        item.UserMail = editUser.UserMail;
                        item.UserTel = editUser.UserTel;
                        item.UserIsSmartAgent = editUser.UserIsSmartAgent;
                        item.UserSmartAgentTime = editUser.UserSmartAgentTime;

                        user = Entities.User.UserEntities(DB.User.FirstOrDefault(d => d.UserId == item.UserId));

                    }
                    DB.SaveChanges();
                    return user;
                }
               

            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        public static HttpResponseMessage EditDetailsBoss(Boss editBoss)
        {
            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    var y = from u in DB.Boss
                            where u.BossId == editBoss.BossId
                            select u;
                    foreach (var item in y)
                    {
                        item.BossName = editBoss.BossName;
                        item.BossPassword = editBoss.BossPassword;
                        item.BossSubId = editBoss.BossSubId;
                        item.BossTel = editBoss.BossTel;
                        item.BossMail = editBoss.BossMail;
                        item.BossCompanyId = editBoss.BossCompanyId;
                        item.BossIsConnection = editBoss.BossIsConnection;
                    }

                    DB.SaveChanges();

                    return new HttpResponseMessage(HttpStatusCode.OK) { };
                }

            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }

        }

        public static string getCv(int idUser)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var x = DB.Cv.FirstOrDefault(c => c.CvUserId == idUser);
                if (x != null)
                {

                    return x.CvLink.Replace('\\', '/');
                }
                return null;
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static Entities.User changePassword(string email, string p1)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var user = DB.User.FirstOrDefault(s => s.UserMail == email);
                if (user != null)
                {
                    user.UserPassword = p1;
                    DB.SaveChanges();
                }
                return Entities.User.UserEntities(user);
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

            public static Entities.Boss GetBossDetailsByIdPassword(int id, string password)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var boss = DB.Boss.FirstOrDefault(b => b.BossId == id && b.BossPassword == password);
                return Entities.Boss.BossEntities(boss);
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }
        public static Entities.User GetUserDetailsByIdPassword(int id, string password)
        {
            try { 
            using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
            {
                DB.Database.Connection.Open();
                var user = DB.User.FirstOrDefault(u => u.UserId == id && u.UserPassword == password);
                return Entities.User.UserEntities(user);
            }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static List<Entities.Recomend> getReccomend(int companyId)
        {
            try
            {
                using (DAL.IdialEntities3 DB = new DAL.IdialEntities3())
                {
                    DB.Database.Connection.Open();
                    List<Entities.Recomend> recomendList = new List<Recomend>();
                    foreach (var item in DB.Recomend)
                    {
                        if (item.RecomemdCompanyId == companyId)
                            recomendList.Add(Entities.Recomend.RecomendEntities(item));
                    }
                    return recomendList;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }


    }
}
