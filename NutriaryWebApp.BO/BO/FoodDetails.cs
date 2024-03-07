using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class FoodDetails
    {
        public int log_id { get; set; }
        public int user_id { get; set; }
        public string food_id { get; set; }
        public decimal quantity { get; set; }
        public DateTime log_date { get; set; }
        public string food_name { get; set; }
        public decimal total_energy_kcal { get; set; }
        public decimal total_protein_g { get; set; }
        public decimal total_fat_g { get; set; }
        public decimal total_carbs_g { get; set; }
        public decimal total_fiber_g { get; set; }
        public decimal total_calcium_mg { get; set; }
        public decimal total_iron_mg { get; set; }
        public decimal total_natrium_mg { get; set; }
    }
}
