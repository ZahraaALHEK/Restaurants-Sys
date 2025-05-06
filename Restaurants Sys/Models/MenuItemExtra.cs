using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    
    public virtual MenuItem MenuItem { get; set; }
    public virtual Extra Extra { get; set; }
}



