# HelloAvalonia
First attempt at using Avalonia UI, on Windows 11.

## Start Project
Following instructions from Avalonia UI from within VS Code, in a powershell terminal.

The dotnet version given was 10.0.104. The Avalonia.Templates installed was version 12.0.1.

The creation of HelloAvalonia seemed to be actually cloning of a template.

```bash
dotnet --version
dotnet new install Avalonia.Templates
dotnet new avalonia.mvvm -o HelloAvalonia
cd HelloAvalonia
dotnet run
```

## Basics
Files generated during project creation include the following.
File [MainWindow.axaml](Views/MainWindow.axaml) is the view.
File [MainWindow.axaml.cs](Views/MainWindow.axaml.cs) is the code-behind for the view.
File [MainWindowViewModel.cs](ViewModels/MainWindowViewModel.cs) is the view model.
File [ViewModelBase.cs](ViewModels/ViewModelBase.cs) is a mystery.
File [App.axaml](App.axaml) is a mystery.
File [App.axaml.cs](App.axaml.cs) is yet another mystery.
File [Program.cs](Program.cs) does what?
File [ViewLocator.cs](ViewLocator.cs) is for what?

So in [MainWindow.axaml](Views/MainWindow.axaml) there is this bit:

```html
<TextBlock Text="{Binding Greeting}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
```

The content is in  [MainWindowViewModel.cs](ViewModels/MainWindowViewModel.cs) thus:

```c#
public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
}
```

