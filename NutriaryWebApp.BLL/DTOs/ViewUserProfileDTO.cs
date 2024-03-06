using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class ViewUserProfileDTO
    {
        public string username { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string ActivityLevel { get; set; }
        public string TargetGoal { get; set; }
    }
}
