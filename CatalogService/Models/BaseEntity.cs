using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Models;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; init; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedUserId { get; set; }
}