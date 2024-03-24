using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class AddFoodConsumptionDTO
    {
        public int UserID { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
    }
}
