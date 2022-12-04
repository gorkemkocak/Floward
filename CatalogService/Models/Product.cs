using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models;

public class Product : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Double Cost { get; set; }
    //public Byte[] Image { get; set; }
}