using NutriaryWebApp.BLL.DTOs;

namespace NutriaryWebMVC.ViewModels
{
    public class DashboardReportViewModel
    {
        public DailyTotalNutritionDTO? dailyTotalNutritionDTO { get; set; }
        public IEnumerable<DailyFoodMenuDTO>? dailyFoodMenuDTO { get; set; }
    }
}
