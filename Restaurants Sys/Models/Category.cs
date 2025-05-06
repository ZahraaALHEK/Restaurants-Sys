using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants_Sys.Models;
[Table("Categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string ? Name { get; set; }
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string ? Description { get; set; }
    [Display(Name = "Image URL")]
    [Url(ErrorMessage = "Invalid URL format")]
    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]
    public string ? ImageUrl { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }

    
    public virtual Restaurant Restaurant { get; set; }
    public virtual ICollection<MenuItem> MenuItems { get; set; }
}
