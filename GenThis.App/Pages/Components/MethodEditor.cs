using System;
using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class MethodEditor : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;
        protected Guid selectedReferenceTypeID;
        protected Guid selectedEnumerationTypeID;

        [Parameter] public Project Project { get; set; }
        [Parameter] public EventCallback<Method> OnOk { get; set; }
        
        Method method;

        public void Show(Method method)
        {
            this.method = method;
            Show();
        }

        protected void Show()
        {
            show = true;
            StateHasChanged();
        }

        public void Ok()
        {
            try
            {
                if (string.IsNullOrEmpty(method.Name)) throw new ApplicationException("Name required");
                method.Name = method.Name.Replace(" ", ""); // name can´t contain spaces
                
                if (method.ReturnTypeKind == TypeKind.Reference)
                {
                    method.ReferenceReturnType = Project.GetClass(selectedReferenceTypeID);
                }
                if (method.ReturnTypeKind == TypeKind.Enumeration)
                {
                    method.EnumReturnType = Project.GetEnumeration(selectedEnumerationTypeID);
                }
                method.Validate();
                OnOk.InvokeAsync(method);
                Hide();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void Hide()
        {
            show = false;
            errorMessage = string.Empty;
            StateHasChanged();
        }
    }
}
