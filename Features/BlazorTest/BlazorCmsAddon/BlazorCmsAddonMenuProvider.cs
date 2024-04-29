using EPiServer.Authorization;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorCmsAddon
{
    [MenuProvider]
    public class BlazorCmsAddonMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Blazor CMS Add-on", "/global/cms/blazorcmsaddon", "/BlazorCmsAddon/Overview");
            adminModule.IsAvailable = context => true;
            adminModule.SortIndex = 1;
            adminModule.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemOverview = new UrlMenuItem("Overview", "/global/cms/blazorcmsaddon/overview", "/BlazorCmsAddon/Overview");
            menuItemOverview.IsAvailable = context => true;
            menuItemOverview.SortIndex = 10;
            menuItemOverview.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemTwo = new UrlMenuItem("Page 2", "/global/cms/blazorcmsaddon/page2", "/BlazorCmsAddon/Page2");
            menuItemTwo.IsAvailable = context => true;
            menuItemTwo.SortIndex = 20;
            menuItemTwo.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            return new MenuItem[]
            {
                adminModule,
                menuItemOverview,
                menuItemTwo
            };
        }
    }
}
