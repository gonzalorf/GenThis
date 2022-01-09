using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class NamespaceCard : ComponentBase
    {
        PromptModal promptNamespaceName;
        ClassEditor classEditor;
        ConfirmModal confirmDeleteNamespace;

        [Parameter]
        public Project Project { get; set; }

        [Parameter]
        public Namespace Namespace { get; set; }

        [Parameter]
        public EventCallback<Namespace> OnDelete { get; set; }

        void OnOkNamespaceName(string name)
        {
            Namespace.Name = name.Replace(" ", ""); // name can´t contain spaces
        }

        void OnDeleteClass(Class deletedClass)
        {
            Namespace.Classes.Remove(deletedClass);
        }

        void OnOkClassEditor(Class editedClass)
        {
            //var newClass = new Class() { Name = name.Replace(" ", "") }; // name can´t contain spaces
            Namespace.Classes.Add(editedClass);
        }

        void OnOkDelete()
        {
            OnDelete.InvokeAsync(Namespace);
        }
    }
}
