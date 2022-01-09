using GenThis.Models;
using Microsoft.AspNetCore.Components;

namespace GenThis.App.Pages.Components
{
    public partial class ClassCard : ComponentBase
    {
        ClassEditor classEditor;
        PropertyEditor propertyEditor;
        ConfirmModal confirmDeleteClass;

        [Parameter]
        public Project Project { get; set; }

        [Parameter]
        public EventCallback<Class> OnDelete { get; set; }

        [Parameter]
        public Class Class { get; set; }

        void OnOkClassEditor(Class editedClass)
        {
            //Class.Name = name.Replace(" ", ""); // name can´t contain spaces
        }

        void OnOkPropertyEditor(Property property)
        {
            //Class.Name = name.Replace(" ", ""); // name can´t contain spaces
            Class.Properties.Add(property);
        }

        void OnOkDelete()
        {
            OnDelete.InvokeAsync(Class);
        }
    }
}
