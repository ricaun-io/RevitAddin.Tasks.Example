using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using ricaun.Revit.UI.Tasks;

namespace RevitAddin.Tasks.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        private static RevitTaskService revitTaskService;
        public static IRevitTask RevitTask => revitTaskService;
        public Result OnStartup(UIControlledApplication application)
        {
            revitTaskService = new RevitTaskService(application);
            revitTaskService.Initialize();

            ribbonPanel = application.CreatePanel("RevitAddin.Tasks.Example");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage("Resources/Revit.ico");
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            revitTaskService?.Dispose();

            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}