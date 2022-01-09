using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class ClassEditor : ComponentBase
    {
        protected bool show = false;

        [Parameter]
        public Project Project { get; set; }

        [Parameter] public EventCallback<Class> OnOk { get; set; }
        Class editClass;

        public void Show(Class editClass)
        {
            this.editClass = editClass;
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
