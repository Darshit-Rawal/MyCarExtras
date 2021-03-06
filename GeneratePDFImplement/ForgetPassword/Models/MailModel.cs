using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForgetPassword.Models
{
    public class MailModel
    {
        public string username { get; set; }
        public string ToMail { get; set; }
        public string password { get; set; }
    }
}