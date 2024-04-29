using EPiServer.Authorization;
using EPiServer.Security;
using EPiServer.Shell.Navigation;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorSetting
{
    [MenuProvider]
    public class BlazorSettingsMenuProvider : IMenuProvider
    {
        private readonly IPrincipalAccessor _principalAccessor;

        public BlazorSettingsMenuProvider(IPrincipalAccessor principalAccessor) => _principalAccessor = principalAccessor;

        public IEnumerable<MenuItem> GetMenuItems()
        {
            var menuItemAccessRights = new UrlMenuItem("Blazor AccessRights", "/global/cms/admin/accessrights/blazoraccessright", "/BlazorSettings/BlazorAccessRight");
            menuItemAccessRights.IsAvailable = context => true;
            menuItemAccessRights.SortIndex = 100;
            menuItemAccessRights.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemScheduleJob = new UrlMenuItem("Blazor ScheduleJob", "/global/cms/admin/scheduledjobs/blazorschedulejob", "/BlazorSettings/BlazorScheduleJob");
            menuItemScheduleJob.IsAvailable = context => true;
            menuItemScheduleJob.SortIndex = 100;
            menuItemScheduleJob.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuItemConfig = new UrlMenuItem("Blazor config", "/global/cms/admin/configurations/blazorconfig", "/BlazorSettings/BlazorConfig");
            menuItemConfig.IsAvailable = context => true;
            menuItemConfig.SortIndex = 100;
            menuItemConfig.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            var menuVisible = _principalAccessor.Principal.IsInRole("CmsAdmins");
            var menuItemTool = new UrlMenuItem("Blazor tool", "/global/cms/admin/tools/blazortool", "/BlazorSettings/BlazorTool");
            menuItemTool.IsAvailable = (Func<HttpContext, bool>) (request => menuVisible);
            menuItemTool.SortIndex = 100;
            menuItemTool.AuthorizationPolicy = CmsPolicyNames.CmsAdmin;

            return new MenuItem[]
            {
                menuItemAccessRights,
                menuItemScheduleJob,
                menuItemConfig,
                menuItemTool
            };
        }
    }
}
