using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkDays.ViewModels;
using IdentityServer4.Services;

namespace WorkDays.Controllers
{
    using WorkDays.Services;

    //[SecurityHeaders]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger,IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Employees = _employeeService.GetEmployees();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
