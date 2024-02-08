using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

using Tamagotchis.Models;

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
  }
}