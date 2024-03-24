using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class UpdateUserProfileDTO
    {
        public int user_id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public int ActivityLevel { get; set; }
        public int TargetGoal { get; set; }
    }
}
