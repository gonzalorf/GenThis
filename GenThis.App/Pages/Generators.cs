using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GenThis.Models;
using GenThis.App.Pages.Components;

namespace GenThis.App.Pages
{
    public partial class Generators : ComponentBase
    {
        ConfirmModal confirmDeleteGenerator;
        string errorMessage = string.Empty;

        IList<string> generators = new List<string>();

        protected override async Task OnInitializedAsync()
        {
        }

    }
}
