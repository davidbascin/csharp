# csharp
Experiments in C#.

## Tools
Use the most recent LTS version of Visual Studio (VS) Community.

## Legal
This work is covered under the [MIT license](LICENSE.txt).
Incorporated third-party work such as NuGet packages are subject to their own licenses.

## Design
The Model View ViewModel (MVVM) architecture is sometimes used along with project management
to aid reuse for different applications and environments.

For throwing together small tools WinForms can be a more direct approach. It is a question of
how to minimize coupling between views and business logic.

## WinFormsApp1

The poorly named [WinFormsApp1](WinFormsApp1/README.md) is a minimal application to test in WinForms C# for instrumentation control using windows forms and C#.

### Mermaid
See [Markdown with embedded diagrams](mermaid.md).

## App1
One way of organizing a MVVM solution in VS.

Created a .net 10 core WPF application.

## Avalonia UI
It is interesting to try out [Avalonia UI](https://avaloniaui.net/) to see about cross-platform C# using open source tooling.

### On PC3
The computer PC3 is the 32-core AMD.
Using Windows 11.
Following instructions from Avalonia UI from within VS Code.

In folder C:\all\csharp. The dotnet version given was 10.0.104.
The Avalonia.Templates installed was version 12.0.1.

The creation of HelloAvalonia seemed to be actually cloning of a template.

```bash
dotnet --version
dotnet new install Avalonia.Templates
dotnet new avalonia.mvvm -o HelloAvalonia
cd HelloAvalonia
dotnet run
```

When run, a window with a simple message appears.
Asked Copilot for suitable content and placed that into [.gitignore](HelloAvalonia/.gitignore).
