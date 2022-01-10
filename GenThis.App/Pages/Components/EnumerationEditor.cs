using System;
using Microsoft.AspNetCore.Components;
using GenThis.Models;

namespace GenThis.App.Pages.Components
{
    public partial class EnumerationEditor : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;
        PromptModal promptAddMember;

        [Parameter]
        public Project Project { get; set; }

        [Parameter] public EventCallback<Enumeration> OnOk { get; set; }
        Enumeration enumeration;

        public void Show(Enumeration enumeration)
        {
            this.enumeration = enumeration;
            Show();
        }

        protected void Ok()
        {
            try
            {
                if (string.IsNullOrEmpty(enumeration.Name)) throw new ApplicationException("Name required");
                enumeration.Name = enumeration.Name.Replace(" ", ""); // name can´t contain spaces
                if (string.IsNullOrEmpty(enumeration.UIName)) enumeration.UIName = enumeration.Name;
                if (string.IsNullOrEmpty(enumeration.UINamePlural)) enumeration.UINamePlural = enumeration.UIName;

                OnOk.InvokeAsync(enumeration);
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
