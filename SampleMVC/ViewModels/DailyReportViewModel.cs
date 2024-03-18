using NutriaryWebApp.BLL.DTOs;

namespace NutriaryWebMVC.ViewModels
{
    public class DailyReportViewModel
    {
        public DailyTotalNutritionDTO? dailyTotalNutritionDTO { get; set; }
        public IEnumerable<DailyFoodMenuDTO>? dailyFoodMenuDTO { get; set; }
    }
}
