using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.Tasks.Example.Services;
using ricaun.Revit.UI;
using System;
using System.Threading.Tasks;

namespace RevitAddin.Tasks.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        private static RevitTaskService revitTaskService;
        public static IRevitTask RevitTask { get; private set; }
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("RevitAddin.Tasks.Example");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage("Resources/Revit.ico");

            revitTaskService = new RevitTaskService(application);
            revitTaskService.Initialize();

            RevitTask = new RevitTask(revitTaskService);

            //var task = Task.Run(async () =>
            //{
            //    await Task.Delay(1000);
            //    await RevitTask.Run(() => { Console.WriteLine("Like this video!"); });
            //    await Task.Delay(1000);
            //    await RevitTask.Run(() => { Console.WriteLine("Subscribe to my channel!"); });
            //});

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();

            revitTaskService.Dispose();

            return Result.Succeeded;
        }
    }

}