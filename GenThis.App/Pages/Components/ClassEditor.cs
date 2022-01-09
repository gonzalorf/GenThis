using System;
using Microsoft.AspNetCore.Components;
using GenThis.Models;

namespace GenThis.App.Pages.Components
{
    public partial class ClassEditor : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;

        [Parameter]
        public Project Project { get; set; }

        [Parameter] public EventCallback<Class> OnOk { get; set; }
        Class editClass;

        public void Show(Class editClass)
        {
            this.editClass = editClass;
            Show();
        }

        protected void Ok()
        {
            try
            {
                if (string.IsNullOrEmpty(editClass.Name)) throw new ApplicationException("Name required");
                editClass.Name = editClass.Name.Replace(" ", ""); // name can´t contain spaces
                if (string.IsNullOrEmpty(editClass.UIName)) editClass.UIName = editClass.Name;
                if (string.IsNullOrEmpty(editClass.UINamePlural)) editClass.UINamePlural = editClass.UIName;
                OnOk.InvokeAsync(editClass);
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
