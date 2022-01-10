using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class EnumerationCard : ComponentBase
    {
        EnumerationEditor enumerationEditor;
        ConfirmModal confirmModal;
        PromptModal promptAddMember;

        [Parameter]
        public Project Project { get; set; }

        [Parameter]
        public EventCallback<Enumeration> OnDelete { get; set; }

        [Parameter]
        public Enumeration Enumeration { get; set; }

        void OnOkEnumerationEditor(Enumeration enumeration)
        {

        }

        void OnOkMemberName(string name)
        {
            if(!Enumeration.Members.Contains(name)) Enumeration.Members.Add(name.Replace(" ", "")); // name can´t contain spaces
        }

        void OnOkDelete()
        {
            switch (confirmModal.Action)
            {
                case "DELETE_ENUMERATION":
                    OnDelete.InvokeAsync(Enumeration);
                    break;
                case "DELETE_MEMBER":
                    Enumeration.Members.Remove(confirmModal.Argument as string);
                    break;
            }
        }
    }
}
