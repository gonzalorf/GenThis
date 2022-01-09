using System;
using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class PropertyEditor : ComponentBase
    {
        protected bool show = false;
        protected string errorMessage = string.Empty;
        protected Guid selectedReferenceTypeID;
        protected Guid selectedEnumerationTypeID;

        [Parameter] public Project Project { get; set; }
        [Parameter] public EventCallback<Property> OnOk { get; set; }
        
        Property property;

        public void Show(Property property)
        {
            this.property = property;
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
                if (string.IsNullOrEmpty(property.Name)) throw new ApplicationException("Name required");
                property.Name = property.Name.Replace(" ", ""); // name can´t contain spaces
                if (string.IsNullOrEmpty(property.UIName)) property.UIName = property.Name;

                if (property.TypeKind == TypeKind.Reference)
                {
                    property.ReferenceType = Project.GetClass(selectedReferenceTypeID);
                }
                if (property.TypeKind == TypeKind.Enumeration)
                {
                    property.EnumerationType = Project.GetEnumeration(selectedEnumerationTypeID);
                }
                property.Validate();
                OnOk.InvokeAsync(property);
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
