using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tamagotchis.Controllers
{
  public class UsersController : Controller
  {
    private readonly TamagotchiContext _db;

    public UsersController(TamagotchiContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<User> users = _db.Users.ToList();
      return View(users);
    }

    [HttpGet("/users/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/users/create")]
    public ActionResult CreateConfirmed(User user)
    {
      _db.Users.Add(user);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
    [HttpGet("/users/show/{id}")]
    public ActionResult Show(int id)
    {
      // Corrected method call to use .Include() and .ThenInclude() with proper casing
      // Assuming your User model correctly defines navigation properties for Pets, and so on.
      // User foundUser = _db.Users.FirstOrDefault(u => u.UserId == id);
      // var user = _db.Users.Find(id);
      
      User user = _db.Users
                    .Include(u => u.Pets) // Assuming User has a navigation property called Pets
                                          //.ThenInclude(p => p.Toys) // Uncomment if Pets have Toys
                                          //.ThenInclude(p => p.Food) // This line might not be necessary as Food might not be directly related to Toys
                    .FirstOrDefault(u => u.UserId == id);

      if (user == null)
      {
        return NotFound();
      }
      return View(user);
    }
  }
}