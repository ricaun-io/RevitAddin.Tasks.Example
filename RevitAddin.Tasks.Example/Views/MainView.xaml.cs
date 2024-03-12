using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ricaun.Revit.Mvvm;
using ricaun.Revit.UI.Drawing;
using ricaun.Revit.UI.Tasks;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace RevitAddin.Tasks.Example.Views
{
    public partial class MainView : Window
    {
        private readonly IRevitTask revitTask;
        public IAsyncRelayCommand ButtonCommand { get; private set; }

        public MainView(IRevitTask revitTask)
        {
            ButtonCommand = new AsyncRelayCommand(Button_Click);

            InitializeComponent();
            InitializeWindow();
            this.revitTask = revitTask;

            this.Loaded += async (s, e) =>
            {
                var title = await revitTask.Run((uiapp) =>
                {
                    Document document = uiapp.ActiveUIDocument.Document;
                    return document.Title;
                });
                Title = title;
            };

        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion

        private async Task Button_Click()
        {
            try
            {
                this.Hide();
                var revitElement = await revitTask.Run((uiapp) =>
                {
                    UIDocument uidoc = uiapp.ActiveUIDocument;
                    Document document = uidoc.Document;
                    View view = uidoc.ActiveView;
                    Selection selection = uidoc.Selection;
                    var reference = selection.PickObject(ObjectType.Element, "Select an element");
                    var element = document.GetElement(reference);
                    return element;
                });

                Title = revitElement.Name;

                var revitElementTypeImage = await revitTask.Run(() =>
                {
                    var element = revitElement;
                    var document = element.Document;

                    element = document.GetElement(element.GetTypeId());

                    if (element is ElementType elementType)
                    {
                        return elementType.GetPreviewImage(new System.Drawing.Size(256, 256));
                    }
                    return null;
                });

                Icon = revitElementTypeImage?.GetBitmapSource();
            }
            finally
            {
                this.Show();
            }
        }

    }
}