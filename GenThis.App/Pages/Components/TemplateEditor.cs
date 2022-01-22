using System;
using Microsoft.AspNetCore.Components;
using GenThis.Models;

namespace GenThis.App.Pages.Components
{
    public partial class TemplateEditor : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;

        [Parameter] public EventCallback<Template> OnOk { get; set; }
        Template template;

        public void Show(Template template)
        {
            this.template = template;
            Show();
        }

        protected void Ok()
        {
            try
            {
                if (string.IsNullOrEmpty(template.Name)) throw new ApplicationException("Name required");
                
                OnOk.InvokeAsync(template);
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
