using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
