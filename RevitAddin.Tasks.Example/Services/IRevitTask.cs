using Autodesk.Revit.UI;
using System;
using System.Threading.Tasks;

namespace RevitAddin.Tasks.Example.Services
{
    public interface IRevitTask
    {
        public Task<TResult> Run<TResult>(Func<UIApplication, TResult> function);
    }

}
