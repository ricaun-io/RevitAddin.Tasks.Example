# RevitAddin.Tasks.Example

`RevitTask` implementation to run Revit code and `await` the code to finish.

[![Revit 2017](https://img.shields.io/badge/Revit-2017+-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)

This project was generated by the [ricaun.AppLoader](https://ricaun.com/AppLoader/) Revit plugin.

## RevitTaskService

The `RevitTaskService` is a service that manages the creation of the `AsyncExternalEventHandler` inside the `Idling` event.

```C#
RevitTaskService revitTaskService = new RevitTaskService();
```

### Initialize

Initialize the `RevitTaskService` to start the `Idling` event.

```C#
revitTaskService.Initialize();
```

### Dispose

Dispose the `RevitTaskService` to stop the `Idling` event.

```C#
revitTaskService.Dispose();
```

## RevitTask

The `RevitTask` is a class that implements the `IRevitTask` interface to run Revit code and `await` the code to finish.
`RevitTask` requires a `RevitTaskService` to run the code inside the `Idling` event.

```C#
IRevitTask revitTask = new RevitTask(revitTaskService);
```

### Run

The `Run` method runs the code inside Revit Context and `await` the code to finish.

```C#
UIApplication uiapp = await revitTask.Run((uiapp) =>
{
    // Code run inside Revit Context
    return uiapp;
});
```

The `IRevitTask` interface has an extension methods for `Run` without `UIApplication` and `return`.

```C#
await revitTask.Run(() => { });
await revitTask.Run(() => { return 1; });
await revitTask.Run((uiapp) => { });
await revitTask.Run((uiapp) => { return 1; });
```

## MVVM

This project uses the [ricaun.Revit.Mvvm](https://github.com/ricaun-io/ricaun.Revit.Mvvm) package to use the `AsyncRelayCommand` and `IAsyncRelayCommand`.

## References

Revit Task references:

* [Revit.Async](https://github.com/KennanChan/Revit.Async)
* [RevitTaks](https://github.com/WhiteSharq/RevitTask)

## Installation

* Download and install [RevitAddin.Tasks.Example.exe](../../releases/latest/download/RevitAddin.Tasks.Example.zip)

## Video

Video in english with the creation of this project.

[![VideoIma1]][Video1]

## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!

[Video1]: https://youtu.be/PxrOxyS-VqY
[VideoIma1]: https://img.youtube.com/vi/PxrOxyS-VqY/mqdefault.jpg