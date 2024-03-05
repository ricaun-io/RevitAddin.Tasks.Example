using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.Mvvm;
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
            var title = await revitTask.Run((uiapp) =>
            {
                Document document = uiapp.ActiveUIDocument.Document;
                return document.Title;
            });
            Title = title;
        }

    }
}