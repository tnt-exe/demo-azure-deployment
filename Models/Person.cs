namespace demo_azure_deployment.Models
{
    public class Person : BaseProp
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Text { get; set; }
    }

    public class BaseProp
    {
        public DateTime CreatedTime { get; set; }
    }
}
