using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class GetFoodInformationByLogIDTO
    {
        public int log_id { get; set; }
        public string food_name { get; set; }
        public decimal quantity { get; set; }
    }
}
