using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorReport
{
    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    public class BlazorReport3Controller : Controller
    {
        private readonly ILogger<BlazorReport3Controller> _logger;


        public BlazorReport3Controller(ILogger<BlazorReport3Controller> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Report3()
        {
            return View("/Features/BlazorTest/BlazorReport/Report3.cshtml");
        }
    }
}