using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorApp.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger) : base()
    {
        _logger = logger;
    }

    public void OnGet()
    {
        if (HttpContext.Session.GetString("UserName") == null)
        {
            System.Diagnostics.Debug.Print("Set Session('UserName') = 'Some Random UserName'");
            HttpContext.Session.SetString("UserName", "Some Random UserName");
        }
        else
        {
            System.Diagnostics.Debug.Print("Session('UserName') has value");
        }
        // ViewData["UserName"] = HttpContext.Session.GetString("UserName");
    }
}

