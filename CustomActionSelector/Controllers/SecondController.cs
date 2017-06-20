using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomActionSelector.Controllers
{
    [Route("sameControllerRoute")]
    public class SecondController : Controller
    {
        public SecondController()
        {
            // different EF Core DataContext than FirstController and possibly other dependencies than FirstController
        }

        [HttpGet("{identifier}/values")]
        public IActionResult Values(string identifier, int number, string somethingElse) // other parameters than FirstController/Values
        {
            return this.Ok("Was in SecondController");

        }
    }
}