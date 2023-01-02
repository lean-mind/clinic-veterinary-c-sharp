using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace clinicVeterinary.API;

/*
 * https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-mvc-app/adding-view?view=aspnetcore-7.0&tabs=visual-studio
 */

public class HelloController: Controller
{
    //
    // GET: /Hello/
    public string Index()
    {
        return "Holi...";
    }
    
    // GET: /Hello/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    public string Welcome(string name, int numTimes = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
}