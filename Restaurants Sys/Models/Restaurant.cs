using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurants_Sys.Models.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
    
    [NotMapped] 
    [Display(Name = "Upload Image")]
    [DataType(DataType.Upload)]
    [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg", ".gif" }, ErrorMessage = "Only .jpg, .png, .jpeg, or .gif allowed")]
    public IFormFile ? LogoImageFile { get; set; }
     [Display(Name = "Image URL")]
    // [Url(ErrorMessage = "Invalid URL format")]
    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]

    public string ? LogoImageUrl { get; set; }
    
   
    [NotMapped] 
    [Display(Name = "Banner Image URL")]
    [DataType(DataType.Upload)]
    [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg", ".gif" }, ErrorMessage = "Only .jpg, .png, .jpeg, or .gif allowed")]
    public IFormFile ? BannerImageFile { get; set; }
     [Display(Name = "Image URL")]
    // [Url(ErrorMessage = "Invalid URL format")]
    [StringLength(500, ErrorMessage = "URL cannot exceed 500 characters")]    
    public string ? BannerImageUrl { get; set; }
    [Display(Name = "WhatsApp Number")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string ? WhatsAppNumber { get; set; }

    [ValidateNever]
    public virtual ICollection<Category>? Categories { get; set; }
    [ValidateNever]
    public virtual ICollection<Order>? Orders { get; set; }
}







