using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class UserLogin
    {
        public int? LoginResult { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
