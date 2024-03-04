using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BO.BO
{
    public class GetAllFood
    {
        public string food_id { get; set; }
        public string food_name { get; set; }
        public decimal energy_kal { get; set; }
        public decimal protein_g { get; set; }
        public decimal fat_g { get; set; }
        public decimal carbs_g { get; set; }
        public decimal fiber_g { get; set; }
        public decimal calcium_mg { get; set; }
        public decimal fe_mg { get; set; }
        public decimal natrium_mg { get; set; }
    }
}
