using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI.Tasks;
using System.Threading.Tasks;

namespace RevitAddin.Tasks.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            Task.Run(async () =>
            {
                await Task.Delay(1000);
                await App.RevitTask.Run((uiapp) =>
                {
                    TaskDialog.Show("Revit", $"Hello from RevitTask {uiapp.ActiveUIDocument.Document.Title}");
                });
            });

            return Result.Succeeded;
        }
    }
}
