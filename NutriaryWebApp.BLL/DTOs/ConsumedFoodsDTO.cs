using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class ConsumedFoodsDTO
    {
        public int log_id { get; set; }
        public int user_id { get; set; }
        public string food_id { get; set; }
        public decimal quantity { get; set; }
        public DateTime log_date { get; set; }
        public string food_name { get; set; }
        public decimal? total_energy_kcal { get; set; }
    }
}
