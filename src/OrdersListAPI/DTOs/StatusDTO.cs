using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.DTOs
{
    public class StatusDTO
    {
        [RegularExpression(@"^[0-9-]*$", ErrorMessage = "Only digits allowed")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only text allowed")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be greater than 3 and lesser than 20 characters!")]
        public string Name { get; set; }
    }
}
