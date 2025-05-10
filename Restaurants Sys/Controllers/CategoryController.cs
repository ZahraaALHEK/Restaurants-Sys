using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Models;
using Restaurants_Sys.Data;

namespace Restaurants_Sys.Controllers;

public class CategoryController : Controller{
   // protected Repository<Restaurant> restaurants ;
    protected Repository<Category> _categories ;
    public CategoryController(RestaurantDbContext context)
    {
         _categories = new Repository<Category>(context);
        //  restaurants = new Repository<Restaurant>(context);
    }
    
    public async Task<IActionResult> Index(int  RestaurantId)
    {
        
    //     IEnumerable<Category> objCat ;
        
    
    // if (RestaurantId.HasValue)
    // {
       
    //     objCat = _db.Categories.Where(c => c.RestaurantId == RestaurantId.Value);
    // }
    // else
    // {
        
    //     objCat = _db.Categories;
    // }
     var categories = await _categories.GetAllFillterAsync(c => c.RestaurantId == RestaurantId);
    return View(categories);
       
    }
    public IActionResult Create(){
        return View();
    }
}