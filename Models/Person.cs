using System.ComponentModel.DataAnnotations;

namespace demo_azure_deployment.Models
{
    public class Person : BaseProp
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Text { get; set; }
    }

    public class BaseProp
    {
        public DateTime CreatedTime { get; set; }
    }
}
