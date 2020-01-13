using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrdersListAPI.Entities
{
    public class StatusEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
