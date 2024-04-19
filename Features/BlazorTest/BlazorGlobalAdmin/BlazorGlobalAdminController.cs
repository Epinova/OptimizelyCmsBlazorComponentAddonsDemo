using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorGlobalAdmin
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorGlobalAdminController : Controller
    {
        private readonly ILogger<BlazorGlobalAdminController> _logger;


        public BlazorGlobalAdminController(ILogger<BlazorGlobalAdminController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Overview()
        {
            return View("/Features/BlazorTest/BlazorGlobalAdmin/Overview.cshtml");
        }

        [Route("[action]")]
        public IActionResult Page2()
        {
            return View("/Features/BlazorTest/BlazorGlobalAdmin/Page2.cshtml");
        }
    }
}