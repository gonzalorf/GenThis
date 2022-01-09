using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http.Json;
using GenThis.App.Pages.Components;
using GenThis.Models;

namespace GenThis.App.Pages
{
    public partial class ProjectPage : ComponentBase
    {
        [Parameter]
        public string ProjectID { get; set; }

        Project project = new Project();
        string errorMessage = string.Empty;

        PromptModal promptProjectName;
        PromptModal promptProjectDescription;
        PromptModal promptNamespaceName;

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrWhiteSpace(ProjectID))
            {
                project = new Project() { Name = "MyNewProject", Description = "Project description..." };
            }
            else
            {
                project = await httpClient.GetFromJsonAsync<Project>("Project/Get?projectID=" + ProjectID);
            }
        }

        void OnOkProjectName(string name)
        {
            project.Name = name.Replace(" ", ""); // name can´t contain spaces
        }

        void OnOkProjectDescription(string description)
        {
            project.Description = description;
        }

        void OnOkNamespaceName(string name)
        {
            var ns = new Namespace() { Name = name.Replace(" ", "") }; // name can´t contain spaces
            project.Namespaces.Add(ns);
        }

        void OnDeleteNamespace(Namespace deletedNamespace)
        {
            project.Namespaces.Remove(deletedNamespace);
        }

        private async Task Save()
        {
            errorMessage = string.Empty;
            var response = await httpClient.PostAsJsonAsync("Project/Save", project);
            var returnData = await response.Content.ReadFromJsonAsync<APIResult<Project>>();

            if (returnData.Result)
            {
                ProjectID = returnData.ReturnData.ID.ToString();
                navigationManager.NavigateTo("projects");
            }
            else
            {
                errorMessage = returnData.Message;
            }
        }
    }
}
