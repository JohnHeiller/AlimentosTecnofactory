using System.ComponentModel.DataAnnotations;

namespace Tecnofactory.Alimentos.DTO
{
    public class UserOrderDto
    {
        public Guid Id { get; set; }
        public Guid CatalogueId { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
