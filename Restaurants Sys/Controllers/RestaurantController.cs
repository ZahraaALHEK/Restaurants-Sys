using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Models;
using Restaurants_Sys.Data;

namespace Restaurants_Sys.Controllers;

public class RestaurantController : Controller{

    // private readonly RestaurantDbContext _db;
    private Repository<Restaurant> restaurants ;
    public RestaurantController(RestaurantDbContext context)
    {
        //  _db = db;
        this.restaurants = new Repository<Restaurant>(context);
    }
    
    public async Task<IActionResult>  Index()
    {
        // IEnumerable<Restaurant> objRest = _db.Restaurants;
        
        return View(await restaurants.GetAllAsync());
    }
    
    [HttpGet]
public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Restaurant res)
{
    if (ModelState.IsValid)
    {
        // Handle file uploads
        if (res.LogoImageFile != null && res.LogoImageFile.Length > 0)
        {
            var logoFileName = Guid.NewGuid().ToString() + Path.GetExtension(res.LogoImageFile.FileName);
            var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", logoFileName);
            
            using (var stream = new FileStream(logoPath, FileMode.Create))
            {
                await res.LogoImageFile.CopyToAsync(stream);
            }
            
            res.LogoImageUrl = "/images/" + logoFileName;
        }

        if (res.BannerImageFile != null && res.BannerImageFile.Length > 0)
        {
            var bannerFileName = Guid.NewGuid().ToString() + Path.GetExtension(res.BannerImageFile.FileName);
            var bannerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", bannerFileName);
            
            using (var stream = new FileStream(bannerPath, FileMode.Create))
            {
                await res.BannerImageFile.CopyToAsync(stream);
            }
            
            res.BannerImageUrl = "/images/" + bannerFileName;
        }

        await restaurants.AddAsync(res);
        return RedirectToAction(nameof(Index));
    }

    return View(res);
}


}