using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        
    }
}
