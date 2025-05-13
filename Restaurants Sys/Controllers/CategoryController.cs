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
         ViewData["RestaurantId"] = RestaurantId;
    
     var categories = await _categories.GetAllFillterAsync(c => c.RestaurantId == RestaurantId);
    return View(categories);
       
    }

    [HttpGet]
public IActionResult Create(int restaurantId)
{
    var category = new Category
    {
        RestaurantId = restaurantId
    };
    
    return View(category);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Category category)
{
    if (ModelState.IsValid)
    {

        if (category.ImageFile != null && category.ImageFile.Length > 0)
        {
            var ImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(category.ImageFile.FileName);
            var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImageFileName);
            
            using (var stream = new FileStream(logoPath, FileMode.Create))
            {
                await category.ImageFile.CopyToAsync(stream);
            }
            
            category.ImageUrl = "/images/" + ImageFileName;
        }

   



        await _categories.AddAsync(category);
        return RedirectToAction("Index", new { restaurantId = category.RestaurantId });
    }
    
    return View(category);
}

}