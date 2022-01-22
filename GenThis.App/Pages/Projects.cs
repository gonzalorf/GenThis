using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GenThis.Models;
using GenThis.App.Pages.Components;
using System;
using Microsoft.JSInterop;

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


        private async Task DownloadFileFromStream()
        {
            var bytes = await httpClient.GetByteArrayAsync("https://localhost:44347/_framework/GenThis.Generators.BlazorApp.dll");

            //load assembly
            var assembly = System.Reflection.Assembly.Load(bytes);

            // get type/method info
            var type = assembly.GetType("GenThis.Generators.BlazorApp.BlazorWasmWithApiGenerator");
            var method = type.GetMethod("GenerateProject");

            // instantiate object and run method
            object classInstance = Activator.CreateInstance(type);
            byte[] result = method.Invoke(classInstance, new object[] { new Project() }) as byte[];

            using var fileRef = DotNetObjectReference.Create(result);

            await JS.InvokeVoidAsync("downloadFileFromStream", "Project.zip", Convert.ToBase64String(result));
        }
    }
}
