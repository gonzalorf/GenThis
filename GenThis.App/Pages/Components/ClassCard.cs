using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class ClassCard : ComponentBase
    {
        ClassEditor classEditor;
        MethodEditor methodEditor;
        PropertyEditor propertyEditor;
        ConfirmModal confirmModal;
        CodeViewer codeViewer;

        [Parameter]
        public Project Project { get; set; }

        [Parameter]
        public EventCallback<Class> OnDelete { get; set; }

        [Parameter]
        public Class Class { get; set; }

        void OnOkClassEditor(Class editedClass)
        {

        }

        void OnOkPropertyEditor(Property property)
        {
            if (!Class.Properties.Contains(property)) Class.Properties.Add(property);
        }

        void OnOkMethodEditor(Method method)
        {
            if(!Class.Methods.Contains(method)) Class.Methods.Add(method);
        }

        void OnOkDelete()
        {
            switch (confirmModal.Action)
            {
                case "DELETE_CLASS":
                    OnDelete.InvokeAsync(Class);
                    break;
                case "DELETE_PROPERTY":
                    Class.Properties.Remove(confirmModal.Argument as Property);
                    break;
                case "DELETE_METHOD":
                    Class.Methods.Remove(confirmModal.Argument as Method);
                    break;
            }
        }
    }
}
