namespace Restaurants_Sys.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

[Table("Orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [Display(Name = "Customer Name")]
    public string ? CustomerName { get; set; }
    [Required(ErrorMessage = "Customer phone is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    [Display(Name = "Customer Phone")]
    public string ? CustomerPhone { get; set; }
    [Required(ErrorMessage = "Customer address is required")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    [Display(Name = "Customer Address")]
    public string ? CustomerAddress { get; set; }
    
    [DataType(DataType.DateTime)]
    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }
    [Display(Name = "WhatsApp Notification Sent")]
    public bool WhatsAppNotificationSent { get; set; }
    
    [Display(Name = "Total Amount")]
    public decimal  TotalAmount { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantId { get; set; }

    [ValidateNever]
    public virtual Restaurant ? Restaurant { get; set; }
    [ValidateNever]
    public virtual ICollection<OrderItem> ? OrderItems { get; set; }
}