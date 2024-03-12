using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demo_azure_deployment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;

        public IndexModel(IConfiguration config)
        {
            this.config = config;
        }

        public string? ConStr { get; set; }
        public string? AppVal1 { get; set; }
        public string? AppVal2 { get; set; }
        public string? AppVal3 { get; set; }
        public string? PropNested { get; set; }

        public void OnGet()
        {
            ConStr = config.GetConnectionString("AppDbMySql");
            AppVal1 = config["AppVal1"];
            AppVal2 = config.GetSection("AppVal2").Value;
            AppVal3 = config.GetValue<string>("AppVal3");
            PropNested = config["AppVal4:PropNested"];
        }
    }
}
