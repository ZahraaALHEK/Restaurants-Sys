using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants_Sys.Models;
[Table("MenuItems")]
public class MenuItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Item name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string ? Name { get; set; }
    [Required]
    public decimal ? Price { get; set; }
    public string ? Description { get; set; }
    [Display(Name = "Image URL")]
    [Url(ErrorMessage = "Invalid URL format")]
    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]
    public string ? ImageUrl { get; set; }
    [Display(Name = "Available")]
    public bool  ? IsAvailable { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<MenuItemExtra> MenuItemExtras { get; set; }
}