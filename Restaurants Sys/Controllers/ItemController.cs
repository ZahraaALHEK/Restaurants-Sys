
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Data;
using Restaurants_Sys.Models;

namespace Restaurants_Sys.Controllers;

public class ItemController : Controller{
    private RestaurantDbContext _context;

protected Repository<MenuItem> _items ;
public ItemController(RestaurantDbContext context)
{
    _context = context;
    _items = new Repository<MenuItem>(context);
}
    public async Task<IActionResult> Index(int  categoryId)
    {
        
    
     var categories = await _items.GetAllFillterAsync(c => c.CategoryId == categoryId);
    return View(categories);
       
    }


}