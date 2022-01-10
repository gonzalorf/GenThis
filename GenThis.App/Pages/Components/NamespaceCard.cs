using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class NamespaceCard : ComponentBase
    {
        PromptModal promptNamespaceName;
        ClassEditor classEditor;
        EnumerationEditor enumerationEditor;
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

        void OnDeleteEnumeration(Enumeration enumeration)
        {
            Namespace.Enumerations.Remove(enumeration);
        }

        void OnOkClassEditor(Class editedClass)
        {
            Namespace.Classes.Add(editedClass);
        }
        void OnOkEnumerationEditor(Enumeration enumeration)
        {
            Namespace.Enumerations.Add(enumeration);
        }

        void OnOkDelete()
        {
            OnDelete.InvokeAsync(Namespace);
        }
    }
}
