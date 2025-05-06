using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Models;
using Restaurants_Sys.Data;

namespace Restaurants_Sys.Controllers;

public class CategoryController : Controller{

    private readonly RestaurantDbContext _db;
    public CategoryController(RestaurantDbContext db)
    {
         _db = db;
    }
    
    public IActionResult Index(int ? RestaurantId)
    {
        
        IEnumerable<Category> objCat ;
        
    
    if (RestaurantId.HasValue)
    {
       
        objCat = _db.Categories.Where(c => c.RestaurantId == RestaurantId.Value);
    }
    else
    {
        
        objCat = _db.Categories;
    }
    
        return View(objCat);
    }
    public IActionResult Create(){
        return View();
    }
}