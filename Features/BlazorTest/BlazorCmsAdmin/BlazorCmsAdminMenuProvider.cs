using EPiServer.Authorization;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorCmsAdmin
{
    [MenuProvider]
    public class BlazorCmsAdminMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Blazor CMS Admin", "/global/cms/blazorcmsadmin", "/BlazorCmsAdmin/Overview");
            adminModule.IsAvailable = context => true;
            adminModule.SortIndex = 1;
            adminModule.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemOverview = new UrlMenuItem("Overview", "/global/cms/blazorcmsadmin/overview", "/BlazorCmsAdmin/Overview");
            menuItemOverview.IsAvailable = context => true;
            menuItemOverview.SortIndex = 10;
            menuItemOverview.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemTwo = new UrlMenuItem("Page 2", "/global/cms/blazorcmsadmin/page2", "/BlazorCmsAdmin/Page2");
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
