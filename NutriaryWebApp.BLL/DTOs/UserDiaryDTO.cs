using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class UserDiaryDTO
    {
        public int diary_id { get; set; }
        public DateTime log_date { get; set; }
        public string notes { get; set; }

    }
}
