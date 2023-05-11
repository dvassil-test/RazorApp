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
        string[] authors = { "Mahesh Chand", "Jeff Prosise", "Dave McCarter", "Allen O'neill",
"Monica Rathbun", "Henry He", "Raj Kumar", "Mark Prime",
"Rose Tracey", "Mike Crown" };
        Random rand = new Random();

        int index = rand.Next(authors.Length);
        // Console.WriteLine($"Randomly selected author is {authors[index]}");

        if (HttpContext.Session.GetString("UserName") == null)
        {
            System.Diagnostics.Debug.Print("Set Session('UserName') = 'Some Random UserName'");
            // HttpContext.Session.SetString("UserName", "Some Random UserName");
            HttpContext.Session.SetString("UserName", authors[index]);
        }
        else
        {
            System.Diagnostics.Debug.Print("Session('UserName') has value");
        }
        // ViewData["UserName"] = HttpContext.Session.GetString("UserName");
    }
}

