using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class ConfirmModal : ComponentBase
    {
        protected bool show = false;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Body { get; set; }

        [Parameter] public EventCallback OnOk { get; set; }

        public void Show(string title, string body)
        {
            Title = title;
            Body = body;
            Show();
        }

        public void Show()
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
