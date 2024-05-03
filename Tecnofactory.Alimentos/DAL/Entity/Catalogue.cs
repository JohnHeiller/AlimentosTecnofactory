using System.ComponentModel.DataAnnotations;

namespace Tecnofactory.Alimentos.DAL.Entity
{
    public class Catalogue
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(250)]
        public string? Name { get; set; }
        [Required]
        [StringLength(600)]
        public string? Description { get; set; }
        [Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}