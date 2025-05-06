using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants_Sys.Models;
[Table("Restaurants")]
public class Restaurant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Restaurant name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public  string ? Name { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    public string ? Phone { get; set; }
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string ? Address { get; set; }
    [Display(Name = "Logo Image URL")]
    [Url(ErrorMessage = "Invalid URL format")]
    public string ? LogoImageUrl { get; set; }
    [Display(Name = "Banner Image URL")]
    [Url(ErrorMessage = "Invalid URL format")]
    public string ? BannerImageUrl { get; set; }
    [Display(Name = "WhatsApp Number")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string ? WhatsAppNumber { get; set; }

    
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}







