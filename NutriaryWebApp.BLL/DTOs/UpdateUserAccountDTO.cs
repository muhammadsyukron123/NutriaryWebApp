﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class UpdateUserAccountDTO
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
