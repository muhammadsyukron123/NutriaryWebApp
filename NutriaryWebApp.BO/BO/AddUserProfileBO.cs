using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class AddUserProfileBO
    {
        public int user_id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public int activity_level_id { get; set; }
        public int target_goal_id { get; set; }
    }
}
