using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomActionSelector.Controllers
{
    [Route("sameControllerRoute")]
    public class FirstController : Controller
    {
        public FirstController()
        {
            // different EF Core DataContext than SecondController and possibly other dependencies than SecondController
        }

        [HttpGet("{identifier}/values")]
        public IActionResult Values(string identifier, DateTime from, DateTime to) // other parameters than SecondController/Values
        {
            return this.Ok("Was in FirstController");

        }
    }
}