using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Models;
using Restaurants_Sys.Data;
using Microsoft.EntityFrameworkCore;

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

[HttpGet]
public async Task<IActionResult> Update(int id)
{
    var restaurant = await restaurants.GetByIdAsync(id, new QueryOptions<Restaurant>());
    
    if (restaurant == null)
    {
        return NotFound();
    }
    
    return View(restaurant);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Update(int id, Restaurant restaurant)
{
    if (id != restaurant.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            // Get the existing restaurant from database
            var existingRestaurant = await restaurants.GetByIdAsync(id, new QueryOptions<Restaurant>());
            
            if (existingRestaurant == null)
            {
                return NotFound();
            }

            // Handle logo image
            if (restaurant.LogoImageFile != null && restaurant.LogoImageFile.Length > 0)
            {
                restaurant.LogoImageUrl = await SaveImage(restaurant.LogoImageFile);
            }
            else
            {
                restaurant.LogoImageUrl = existingRestaurant.LogoImageUrl;
            }

            // Handle banner image
            if (restaurant.BannerImageFile != null && restaurant.BannerImageFile.Length > 0)
            {
                restaurant.BannerImageUrl = await SaveImage(restaurant.BannerImageFile);
            }
            else
            {
                restaurant.BannerImageUrl = existingRestaurant.BannerImageUrl;
            }

            // Update other properties
            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Phone = restaurant.Phone;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.WhatsAppNumber = restaurant.WhatsAppNumber;
            existingRestaurant.LogoImageUrl = restaurant.LogoImageUrl;
            existingRestaurant.BannerImageUrl = restaurant.BannerImageUrl;

            await restaurants.UpdateAsync(existingRestaurant);
            
           // TempData["success"] = "Restaurant updated successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await RestaurantExists(restaurant.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }
    
    return View(restaurant);
}

private async Task<bool> RestaurantExists(int id)
{
    return await restaurants.GetByIdAsync(id, new QueryOptions<Restaurant>()) != null;
}

private async Task<string> SaveImage(IFormFile imageFile)
{
    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await imageFile.CopyToAsync(stream);
    }

    return $"/images/{fileName}";
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
   
    [HttpGet]
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var options = new QueryOptions<Restaurant>
    {
        Includes = "Categories,Orders"
    };

    var restaurant = await restaurants.GetByIdAsync(id.Value, options);
    
    if (restaurant == null)
    {
        return NotFound();
    }

    return View(restaurant);
}

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
        await restaurants.DeleteAsync(id);
            
        return RedirectToAction(nameof(Index));
}


    

// [HttpGet]
// public async Task<IActionResult> Delete(int id){
//     return View(await restaurants.GetByIdAsync(id,new QueryOptions<Restaurant>{Includes = "Categories"}));


// }
// [HttpPost]
// [ValidateAntiForgeryToken]
// public async Task<IActionResult> Delete(Restaurant restaurant){
//     await restaurants.DeleteAsync(restaurant.Id);
//     return RedirectToAction("Index");
// }
}