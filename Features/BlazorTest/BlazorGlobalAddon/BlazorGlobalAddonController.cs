using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorGlobalAddon
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorGlobalAddonController : Controller
    {
        private readonly ILogger<BlazorGlobalAddonController> _logger;


        public BlazorGlobalAddonController(ILogger<BlazorGlobalAddonController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Overview()
        {
            return View("/Features/BlazorTest/BlazorGlobalAddon/Overview.cshtml");
        }

        [Route("[action]")]
        public IActionResult Page2()
        {
            return View("/Features/BlazorTest/BlazorGlobalAddon/Page2.cshtml");
        }
    }
}