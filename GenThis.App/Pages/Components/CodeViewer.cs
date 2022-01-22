using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using GenThis.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GenThis.App.Pages.Components
{
    public partial class CodeViewer : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;
        protected string currentElementName = string.Empty;
        IList<Template> templates;
        protected Guid selectedTemplateID;

        [Parameter]
        public Project Project { get; set; }

        [Parameter] public EventCallback OnOk { get; set; }
        Class codeClass;
        Enumeration codeEnumeration;
        string genResult;

        public async void ShowForClass(Class codeClass)
        {
            this.codeClass = codeClass;
            currentElementName = codeClass.Name;
            templates = await httpClient.GetFromJsonAsync<IList<Template>>("Template/GetAll");
            Show();
        }

        public async void ShowForEnumeration(Enumeration codeEnumeration)
        {
            this.codeEnumeration = codeEnumeration;
            currentElementName = codeEnumeration.Name;
            templates = await httpClient.GetFromJsonAsync<IList<Template>>("Template/GetAll");
            Show();
        }

        protected void Generate()
        {
            try
            {
                var template = Scriban.Template.Parse(templates[0].Content);
                genResult = template.Render(new { Project = Project, Namespace = Project.GetClassNamespace(codeClass.Id.ToString()), Class = codeClass });

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        protected void Download()
        {
            try
            {
                if (string.IsNullOrEmpty(codeClass.Name)) throw new ApplicationException("Name required");
                codeClass.Name = codeClass.Name.Replace(" ", ""); // name can´t contain spaces
                if (string.IsNullOrEmpty(codeClass.UIName)) codeClass.UIName = codeClass.Name;
                if (string.IsNullOrEmpty(codeClass.UINamePlural)) codeClass.UINamePlural = codeClass.UIName;

                OnOk.InvokeAsync();
                Hide();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        protected void Show()
        {
            show = true;
            StateHasChanged();
        }

        public void Hide()
        {
            show = false;
            errorMessage = string.Empty;
            StateHasChanged();
        }
    }
}
