using EPiServer.Shell.ViewComposition;
using Microsoft.AspNetCore.Mvc;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorGadget
{
    [Route("[controller]")]
    [IFrameComponent(Url = "~/BlazorGadget", Title = "Blazor gadget", Categories = "content", PlugInAreas = "/episerver/cms/assets", MaxHeight = 650, MinHeight = 200)]
    public class BlazorGadgetController : Controller
    {
        private ContentReference _currentLink;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContentRepository _contentRepository;

        protected BlazorGadgetViewModel ViewModel { get; set; }

        public BlazorGadgetController(IHttpContextAccessor httpContextAccessor, IContentRepository contentRepository)
        {
            ViewModel = new BlazorGadgetViewModel();
            _httpContextAccessor = httpContextAccessor;
            _contentRepository = contentRepository ?? throw new ArgumentNullException(nameof(contentRepository));
        }

        public ContentReference CurrentContentLink
        {
            get
            {
                if (ContentReference.IsNullOrEmpty(_currentLink))
                {
                    if (ContentReference.IsNullOrEmpty(_currentLink))
                        ContentReference.TryParse((string)_httpContextAccessor.HttpContext?.Request.Query["id"], out _currentLink);
                    if (ContentReference.IsNullOrEmpty(_currentLink))
                    {
                        _currentLink = ContentReference.StartPage;
                        if (ContentReference.IsNullOrEmpty(_currentLink))
                            _currentLink = ContentReference.RootPage;
                    }
                }
                return _currentLink;
            }
            set => _currentLink = value;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewModel.ContentReference = CurrentContentLink;

            return View("/Features/BlazorTest/BlazorGadget/BlazorGadgetView.cshtml", ViewModel);
        }
    }
}