using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        //[HttpGet] // This needs to be a HttpGet to work. If we use "[Route("[action]")]" it will not work.
        public IActionResult Report1()
        {
            //var viewModel = new OverviewViewModel();
            //return View("/Features/BlazorGadget/AdminOverview.cshtml", viewModel);
            return View("/Features/BlazorTest/BlazorReport/Report1.cshtml");
        }

        [Route("[action]")]
        public IActionResult Report2()
        {
            //var viewModel = new OverviewViewModel();
            //return View("/Features/BlazorGadget/AdminOverview.cshtml", viewModel);
            return View("/Features/BlazorTest/BlazorReport/Report2.cshtml");
        }
    }
}