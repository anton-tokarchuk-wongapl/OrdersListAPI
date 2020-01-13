using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.DTOs
{
    public class ProductDTO
    {
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only text allowed")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Name should be greater than 3 and lesser than 35 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}
