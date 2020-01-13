using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public ProductEntity Product { get; set; }

        [Required]
        public int StatusId { get; set; }

        public StatusEntity Status { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
