using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SauHavk.Data;
using SauHavk.Models;

public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var currentDateTime = DateTime.Now;

        // Geçmiş etkinlikler
        var pastEvents = _context.Events
            .Where(e => e.EventDate < currentDateTime)
            .OrderByDescending(e => e.EventDate)
            .ToList();

        // Gelecek etkinlikler
        var futureEvents = _context.Events
            .Where(e => e.EventDate >= currentDateTime)
            .OrderBy(e => e.EventDate)
            .ToList();

        ViewBag.PastEvents = pastEvents;
        ViewBag.FutureEvents = futureEvents;

        return View("~/Views/Home/Events.cshtml");
    }

}
