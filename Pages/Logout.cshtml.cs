
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorApp.Pages;

public class LogoutModel : PageModel
{
    private readonly ILogger<LogoutModel> _logger;

    public LogoutModel(ILogger<LogoutModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        System.Diagnostics.Debug.Print("Test breakpoint on Logout::OnGet");
        HttpContext.Session.Clear();
        // Response.Clear();
        return LocalRedirect("~/");
    }
}

