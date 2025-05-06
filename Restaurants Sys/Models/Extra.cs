using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants_Sys.Models;
[Table("Extras")]
public class Extra
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required(ErrorMessage = "Extra name is required")]
    public string ? Name  { get; set; }
    [Required]
    public decimal ? Price { get; set; }


    public virtual ICollection<MenuItemExtra> MenuItemExtras { get; set; }
    public virtual ICollection<OrderItemExtra> OrderItemExtras { get; set; }
}    