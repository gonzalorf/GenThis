﻿using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class PromptModal : ComponentBase
    {
        protected bool show = false;
        protected string text = string.Empty;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Body { get; set; }

        [Parameter] public EventCallback<string> OnOk { get; set; }

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
