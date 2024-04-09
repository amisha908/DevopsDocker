using System.ComponentModel.DataAnnotations;

namespace MyDockerDevopsApplication.DataModel
{
    public class ProductDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public string Category { get; set; }
        public float Price { get; set; }

    }
}
