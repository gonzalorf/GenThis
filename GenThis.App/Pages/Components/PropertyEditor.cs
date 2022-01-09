using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class PropertyEditor : ComponentBase
    {
        protected bool show = false;

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

        public void Hide()
        {
            show = false;
            StateHasChanged();
        }
    }
}
