using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants_Sys.Models;
[Table("OrderItems")]
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int ? Quantity { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    [ForeignKey("MenuItem")]
    public int MenuItemId { get; set; }

    public virtual Order Order { get; set; }
    public virtual MenuItem MenuItem { get; set; }
    public virtual ICollection<OrderItemExtra> OrderItemExtras { get; set; }
}
