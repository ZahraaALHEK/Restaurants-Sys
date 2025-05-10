using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Restaurants_Sys.Models;
// OrderItemExtra.cs (junction table for OrderItem and Extra many-to-many)
[Table("OrderItemExtras")]
public class OrderItemExtra
{
    [Key, Column(Order = 0)]
    [ForeignKey("OrderItem")]
    public int OrderItemId { get; set; }
    [Key, Column(Order = 1)]
    [ForeignKey("Extra")]
    public int ExtraId { get; set; }


    [ValidateNever]
    public virtual OrderItem? OrderItem { get; set; }
    [ValidateNever]
    public virtual Extra? Extra { get; set; }
}