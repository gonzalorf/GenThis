using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GenThis.Models;

namespace GenThis.App.Pages
{
    public partial class Projects : ComponentBase
    {
        IList<Project> projects = new List<Project>();

        protected override async Task OnInitializedAsync()
        {
            projects = await httpClient.GetFromJsonAsync<IList<Project>>("Project/GetAll");
        }
    }
}
