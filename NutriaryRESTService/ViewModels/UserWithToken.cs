namespace NutriaryRESTService.ViewModels
{
    public class UserWithToken
    {
        public int user_id { get; set; }
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;   
        public string lastname { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;

    }
}
