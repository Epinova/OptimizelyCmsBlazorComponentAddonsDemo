using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorCmsAddon
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorCmsAddonController : Controller
    {
        private readonly ILogger<BlazorCmsAddonController> _logger;


        public BlazorCmsAddonController(ILogger<BlazorCmsAddonController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Overview()
        {
            return View("/Features/BlazorTest/BlazorCmsAddon/Overview.cshtml");
        }

        [Route("[action]")]
        public IActionResult Page2()
        {
            return View("/Features/BlazorTest/BlazorCmsAddon/Page2.cshtml");
        }
    }
}