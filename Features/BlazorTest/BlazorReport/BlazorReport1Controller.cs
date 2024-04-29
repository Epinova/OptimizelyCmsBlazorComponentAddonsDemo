using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorReport
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorReport1Controller : Controller
    {
        private readonly ILogger<BlazorReport1Controller> _logger;

        public BlazorReport1Controller(ILogger<BlazorReport1Controller> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Report1()
        {
            return View("/Features/BlazorTest/BlazorReport/Report1.cshtml");
        }

        [Route("[action]")]
        public IActionResult Report2()
        {
            return View("/Features/BlazorTest/BlazorReport/Report2.cshtml");
        }
    }
}