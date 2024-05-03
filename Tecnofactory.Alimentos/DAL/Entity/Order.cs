using System.ComponentModel.DataAnnotations;

namespace Tecnofactory.Alimentos.DAL.Entity
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CatalogueId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string? Email { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
