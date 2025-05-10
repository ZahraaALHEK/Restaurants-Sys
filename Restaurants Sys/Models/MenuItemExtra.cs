using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Restaurants_Sys.Models;
[Table("MenuItemExtras")]
public class MenuItemExtra
{
    [Key, Column(Order = 0)]
    [ForeignKey("MenuItem")]
    public int MenuItemId { get; set; }
    [Key, Column(Order = 1)]
    [ForeignKey("Extra")]
    public int ExtraId { get; set; }

    [ValidateNever]
    public virtual MenuItem ? MenuItem { get; set; }
    [ValidateNever]
    public virtual Extra? Extra { get; set; }
}



