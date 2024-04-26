using Dapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.SqlClient;
using Microsoft.JSInterop;

namespace OptimizelyCmsBlazorComponentAddonsDemo.Features.BlazorTest.BlazorReport
{
    public class Report1ComponentBase : ComponentBase
    {
        [Inject]
        protected ILogger<Report1ComponentBase> Logger { get; set; }

        [Inject]
        protected IConfiguration Configuration { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        protected override async void OnInitialized()
        {
            await JsRuntime.InvokeVoidAsync("Spinner");
            await JsRuntime.InvokeVoidAsync("Spinner.hide");
        }

        protected List<Report1ResultDto> Items { get; set; }
        protected string? SearchString;
        protected bool IsLoading;

        protected async Task SearchForContent(MouseEventArgs e)
        {
            Items = new List<Report1ResultDto>();

            IsLoading = true;
            await JsRuntime.InvokeVoidAsync("Spinner.show");

            try
            {
                Items.AddRange(await ListFoundContent(SearchString));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Something is rotten...");
            }

            IsLoading = false;
            await JsRuntime.InvokeVoidAsync("Spinner.hide");
        }

        private async Task<IEnumerable<Report1ResultDto>> ListFoundContent(string searchString)
        {
            var list = default(IEnumerable<Report1ResultDto>);

            var connectionString = Configuration.GetConnectionString("EPiServerDB");
            using (var connection = new SqlConnection(connectionString))
            {
                list = await connection.QueryAsync<Report1ResultDto>($"SELECT fkContentID AS ContentID, (SELECT TOP 1 Name FROM tblWorkCOntent WHERE fkContentID = tCP.fkContentID ORDER BY Saved DESC) AS ContentName, (SELECT Name FROM tblPropertyDefinition WHERE pkID = tCP.fkPropertyDefinitionID) AS PropertyName, (SELECT LanguageID FROM tblLanguageBranch WHERE pkID = tCP.fkLanguageBranchID) AS LanguageCode, '' AS Link, (SELECT ContentPath FROM tblContent WHERE pkID = tCP.fkContentID) AS ContentPath FROM tblContentProperty AS tCP WHERE LongString LIKE '%{searchString}%'");
            }

            foreach (var item in list) {
                item.Link = $"/EPiServer/CMS/#context=epi.cms.contentdata:///{item.ContentId}&viewsetting=viewlanguage:///{item.LanguageCode}";
            }

            return list;
        }
    }

    public class Report1ResultDto
    {
        public int ContentId;
        public string ContentName;
        public string PropertyName;
        public string LanguageCode;
        public string Link;
        public string ContentPath;
    }
}
