using System.Collections.Generic;
using EPiServer.Authorization;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorGlobalAddon
{
    [MenuProvider]
    public class BlazorGlobalAddonMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Blazor Global Add-on", "/global/blazorglobaladdon", "/BlazorGlobalAddon/Overview");
            adminModule.IsAvailable = context => true;
            adminModule.SortIndex = 1;
            adminModule.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemOverview = new UrlMenuItem("Overview", "/global/blazorglobaladdon/overview", "/BlazorGlobalAddon/Overview");
            menuItemOverview.IsAvailable = context => true;
            menuItemOverview.SortIndex = 10;
            menuItemOverview.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemTwo = new UrlMenuItem("Page 2", "/global/blazorglobaladdon/page2", "/BlazorGlobalAddon/Page2");
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
