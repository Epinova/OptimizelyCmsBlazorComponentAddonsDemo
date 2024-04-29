using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorSetting
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorSettingsController : Controller
    {
        private readonly ILogger<BlazorSettingsController> _logger;


        public BlazorSettingsController(ILogger<BlazorSettingsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult BlazorAccessRight()
        {
            return View("/Features/BlazorTest/BlazorSetting/BlazorAccessRight.cshtml");
        }

        [Route("[action]")]
        public IActionResult BlazorScheduleJob()
        {
            return View("/Features/BlazorTest/BlazorSetting/BlazorScheduleJob.cshtml");
        }

        [Route("[action]")]
        public IActionResult BlazorConfig()
        {
            return View("/Features/BlazorTest/BlazorSetting/BlazorConfig.cshtml");
        }

        [Route("[action]")]
        public IActionResult BlazorTool()
        {
            return View("/Features/BlazorTest/BlazorSetting/BlazorTool.cshtml");
        }
    }
}