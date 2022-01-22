using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GenThis.Models;
using GenThis.App.Pages.Components;

namespace GenThis.App.Pages
{
    public partial class Templates : ComponentBase
    {
        ConfirmModal confirmDeleteTemplate;
        TemplateEditor templateEditor;
        string errorMessage = string.Empty;

        IList<Template> templates = new List<Template>();

        protected override async Task OnInitializedAsync()
        {
            templates = await httpClient.GetFromJsonAsync<IList<Template>>("Template/GetAll");
        }
        async void OnOkTemplateEditor(Template editedTemplate)
        {
            errorMessage = string.Empty;
            var response = await httpClient.PostAsJsonAsync("Template/Save", editedTemplate);
            var returnData = await response.Content.ReadFromJsonAsync<APIResult<Template>>();

            if (returnData.Result)
            {
                templates = await httpClient.GetFromJsonAsync<IList<Template>>("Template/GetAll");
                StateHasChanged();
            }
            else
            {
                errorMessage = returnData.Message;
            }
        }

        async void OnOkDeleteTemplate()
        {
            var template = confirmDeleteTemplate.Argument as Template;
            var result = await httpClient.DeleteAsync("Template/Delete?id=" + template.Id);
            templates = await httpClient.GetFromJsonAsync<IList<Template>>("Template/GetAll");
            StateHasChanged();
        }
    }
}
