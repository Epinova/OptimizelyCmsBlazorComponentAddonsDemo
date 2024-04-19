using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorCmsAdmin
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorCmsAdminController : Controller
    {
        private readonly ILogger<BlazorCmsAdminController> _logger;


        public BlazorCmsAdminController(ILogger<BlazorCmsAdminController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Overview()
        {
            return View("/Features/BlazorTest/BlazorCmsAdmin/Overview.cshtml");
        }

        [Route("[action]")]
        public IActionResult Page2()
        {
            return View("/Features/BlazorTest/BlazorCmsAdmin/Page2.cshtml");
        }
    }
}