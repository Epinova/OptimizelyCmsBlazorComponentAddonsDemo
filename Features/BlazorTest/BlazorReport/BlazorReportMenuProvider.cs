using EPiServer.Authorization;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorReport
{
    [MenuProvider]
    public class BlazorReportMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {

            //https://docs.developers.optimizely.com/content-management-system/docs/using-menu-providers
            var optimizelyReports = new UrlMenuItem("Optimizely Reports", "/global/cms/report/episerver", "/EPiServer/CMS/reports");
            optimizelyReports.IsAvailable = context => true;
            optimizelyReports.SortIndex = 100;


            var menuItemReport1 = new UrlMenuItem("Blazor Report 1", "/global/cms/report/blazorreport1", "/BlazorReport1/Report1");
            menuItemReport1.IsAvailable = context => true;
            menuItemReport1.SortIndex = 910;
            menuItemReport1.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemReport2 = new UrlMenuItem("Blazor Report 2", "/global/cms/report/blazorreport2", "/BlazorReport1/Report2");
            menuItemReport2.IsAvailable = context => true;
            menuItemReport2.SortIndex = 920;
            menuItemReport2.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemReport3 = new UrlMenuItem("Blazor Report 3", "/global/cms/report/blazorreport3", "/BlazorReport3/Report3");
            menuItemReport3.IsAvailable = context => true;
            menuItemReport3.SortIndex = 930;
            menuItemReport3.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            return new MenuItem[]
            {
                optimizelyReports,
                menuItemReport1,
                menuItemReport2,
                menuItemReport3
            };
        }
    }
}
