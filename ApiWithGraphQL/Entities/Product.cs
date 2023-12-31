﻿using System.ComponentModel.DataAnnotations;

namespace ApiWithGraphQL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = default!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; } = default!;

        public float Stock { get; set; }
        public DateTime Date { get; set; }

        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}
