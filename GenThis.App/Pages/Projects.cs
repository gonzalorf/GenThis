using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GenThis.Models;
using GenThis.App.Pages.Components;

namespace GenThis.App.Pages
{
    public partial class Projects : ComponentBase
    {
        ConfirmModal confirmDeleteProject;

        IList<Project> projects = new List<Project>();

        protected override async Task OnInitializedAsync()
        {
            projects = await httpClient.GetFromJsonAsync<IList<Project>>("Project/GetAll");
        }
        async void OnOkDeleteProject()
        {
            var project = confirmDeleteProject.Argument as Project;
            var result = await httpClient.DeleteAsync("Project/Delete?id=" + project.Id);
            projects = await httpClient.GetFromJsonAsync<IList<Project>>("Project/GetAll");
            StateHasChanged();
        }
    }
}
