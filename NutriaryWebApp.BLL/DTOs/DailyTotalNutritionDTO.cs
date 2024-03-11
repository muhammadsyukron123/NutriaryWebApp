using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class DailyTotalNutritionDTO
    {
        public int user_id { get; set; }
        public DateTime? log_date { get; set; }
        public decimal? total_energy_kal { get; set; }
        public decimal? total_protein_g { get; set; }
        public decimal? total_fat_g { get; set; }
        public decimal? total_carbs_g { get; set; }
        public decimal? total_fiber_g { get; set; }
        public decimal? total_calcium_mg { get; set; }
        public decimal? total_fe_mg { get; set; }
        public decimal? total_natrium_mg { get; set; }
        public decimal? total_bmr { get; set; }
        public decimal? remaining_bmr { get; set; }
    }
}
