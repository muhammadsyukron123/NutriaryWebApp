using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class CalorieSummaryDTO
    {
        public int? user_id { get; set; }
        public DateTime? log_date { get; set; }
        public decimal? BMR { get; set; }
        public decimal? consumed_calories { get; set; }
        public decimal? remaining_calories { get; set; }
    }
}
