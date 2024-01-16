using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.Tasks.Example.Services;
using RevitAddin.Tasks.Example.Views;
using System;
using System.Threading.Tasks;

namespace RevitAddin.Tasks.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            new MainView(App.RevitTask).Show();

            return Result.Succeeded;
        }
    }
}
