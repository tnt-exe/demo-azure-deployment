using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demo_azure_deployment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment environment;

        public IndexModel(IConfiguration config, IWebHostEnvironment environment)
        {
            this.config = config;
            this.environment = environment;
        }

        public string? ConStr { get; set; }
        public string? AppVal1 { get; set; }
        public string? AppVal2 { get; set; }
        public string? AppVal3 { get; set; }
        public string? PropNested { get; set; }
        public string? Env {get; set; }

        public void OnGet()
        {
            ConStr = config.GetConnectionString("AppDbMySql");
            AppVal1 = config["AppVal1"];
            AppVal2 = config.GetSection("AppVal2").Value;
            AppVal3 = config.GetValue<string>("AppVal3");
            PropNested = config["AppVal4:PropNested"];

            Env = environment.EnvironmentName;
        }
    }
}
