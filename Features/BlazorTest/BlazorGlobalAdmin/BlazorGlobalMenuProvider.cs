using System.Collections.Generic;
using EPiServer.Authorization;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorGlobalAdmin
{
    [MenuProvider]
    public class BlazorGlobalMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Blazor Global Admin", "/global/blazorglobaladmin", "/BlazorGlobalAdmin/Overview");
            adminModule.IsAvailable = context => true;
            adminModule.SortIndex = 1;
            adminModule.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemOverview = new UrlMenuItem("Overview", "/global/blazorglobaladmin/overview", "/BlazorGlobalAdmin/Overview");
            menuItemOverview.IsAvailable = context => true;
            menuItemOverview.SortIndex = 10;
            menuItemOverview.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemTwo = new UrlMenuItem("Page 2", "/global/blazorglobaladmin/page2", "/BlazorGlobalAdmin/Page2");
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
