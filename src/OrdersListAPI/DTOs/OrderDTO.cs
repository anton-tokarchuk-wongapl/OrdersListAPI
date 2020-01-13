using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.DTOs
{
    public class OrderDTO
    {
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "StatusId is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Count is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int Count { get; set; }
    }
}
