using Microsoft.AspNetCore.Mvc;
using SauHavk.Data;
using SauHavk.Models;
using System.Linq;

public class AdminController : Controller
{
    private const string AdminPassword = "--------------------------------------------------";
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult AdminLogin()
    {
        if (HttpContext.Session.GetString("IsAdmin") == "true")
        {
            return RedirectToAction("AdminPanel");
        }

        return View("~/Views/Home/AdminLogin.cshtml");
    }

    [HttpPost]
    public IActionResult AdminLogin(string password)
    {
        if (password == AdminPassword)
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToAction("AdminPanel");
        }

        ViewBag.Error = "Hatalı şifre! Lütfen tekrar deneyin.";
        return View("~/Views/Home/AdminLogin.cshtml");
    }

    [HttpGet]
    public IActionResult AdminPanel()
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("AdminLogin");
        }

        // Veritabanından etkinlikleri getir
        var events = _context.Events.ToList();
        return View("~/Views/Home/AdminPanel.cshtml", events);
    }

    [HttpPost]
    public IActionResult AddEvent(string name, string description, DateTime eventDate)
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("AdminLogin");
        }

        var newEvent = new Events
        {
            Name = name,
            Description = description,
            EventDate = eventDate,
            CreatedAt = DateTime.Now
        };

        _context.Events.Add(newEvent);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Etkinlik başarıyla eklendi!";
        return RedirectToAction("AdminPanel");
    }

    [HttpPost]
    public IActionResult DeleteEvent(int id)
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("AdminLogin");
        }

        // Etkinliği veritabanından bul ve sil
        var eventToDelete = _context.Events.FirstOrDefault(e => e.Id == id);
        if (eventToDelete != null)
        {
            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Etkinlik başarıyla silindi!";
        }
        else
        {
            TempData["ErrorMessage"] = "Etkinlik bulunamadı!";
        }

        return RedirectToAction("AdminPanel");
    }
}
