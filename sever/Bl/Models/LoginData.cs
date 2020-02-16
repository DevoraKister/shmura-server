using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Models
{
    public class LoginData
    {
        public string TokenJson { get; set; }

        public Entities.User User { get; set; }

    }
}