﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class UpdateUserProfileBO
    {
        public int user_id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string ActivityLevel { get; set; }
        public string TargetGoal { get; set; }
    }
}