using System.ComponentModel.DataAnnotations;

namespace Tecnofactory.Alimentos.DAL.Entity
{
    public class Catalogue
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}