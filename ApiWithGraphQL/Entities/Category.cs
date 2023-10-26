using System.ComponentModel.DataAnnotations;

namespace ApiWithGraphQL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(300)]
        public string ImageUrl { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
