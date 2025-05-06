using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurants_Sys.Models;
using Restaurants_Sys.Data;

namespace Restaurants_Sys.Controllers;

public class RestaurantController : Controller{

    private readonly RestaurantDbContext _db;
    public RestaurantController(RestaurantDbContext db)
    {
         _db = db;
    }
    
    public IActionResult Index()
    {
        IEnumerable<Restaurant> objRest = _db.Restaurants;
        return View(objRest);
    }
    
    public IActionResult create()
    {
       
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult create(Restaurant res)
    {
        _db.Restaurants.Add(res);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


}