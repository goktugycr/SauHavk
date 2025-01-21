using Microsoft.AspNetCore.Mvc;

public class ContactController : Controller
{
    private readonly EmailService _emailService;

    public ContactController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public IActionResult SendMail(string name, string email, string message)
    {
        try
        {
            var body = $"Ad Soyad: {name}\nE-posta: {email}\nMesaj: {message}";
            _emailService.SendEmail("goktug858@gmail.com", "İletişim Formu Mesajı", body);

            ViewBag.Message = "Mesaj başarıyla gönderildi!";
            ViewBag.MessageType = "info";
        }
        catch (Exception ex)
        {
            ViewBag.Message = $"Hata oluştu: {ex.Message}";
            ViewBag.MessageType = "danger";
        }

        return View("~/Views/Home/Contact.cshtml");
    }

}
