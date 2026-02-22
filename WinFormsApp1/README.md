# WinFormsApp1
Minimal application to test in WinForms C# for instrumentation control.

## Requirements
An instrument control tool for the home lab that can be extended to run automated tests,
add other instruments etc.

### Implemented
+ A fixed width left side tree view of categories that swaps the UI on the right side.
+ The right side UI resizes with the window.
+ A JSON file that is loaded when run, created if not existing, to hold instrument settings,
program options and user preferences.
+ Use a view method to disable MainView UI controls as needed while communicating.
+ Click the status bar message and it is copied to the clipboard, or if a double-quoted part exists
just that double-quoted part is copied with the quotes.

### Planned
+ A compiled .exe that can be copied to a workstation and run without installation.
+ Uses TCP/IP sockets to talk to the instrument.
+ Apply async/await for instrument I/O to keep the UI responsive.
+ Get instrument identity to start with.
+ Instrument connections open only for the duration of the command or query.
+ Provide a means to stop operations from MainView that run async/await initiated by user controls.

### Parked
+ Use LINQ to provide flexibility in handling data.
+ Add OxyPlot to show waveform data.

## WinFormsApp1 Implementation
In VS create a C# WinForms application as a solution an set up a MainView form.
+ Rename Form1 to MainView and set the size to 800,450.
+ In MainView.cs add a semicolon after namespace WinFormsApp1 which will collapse braces one level.
+ On MainView add a StatusStrip then select StatusLabel to get toolStripStatusLabel1 indicator.
+ Add a SplitContainer. Set SplitterDistance to 240 and IsSplitterFixed True.
+ On splitterContainer1 set FixedPanel to Panel1.
+ Set left Panel1 background color to Gainsboro.
+ Set right Panel2 Dock = fill.
+ Add a Button to left Panel1 then set FlatStyle to Flat and set FlatAppearance.BorderSize to 0 and Size.Width to 220, Font.ForeColor to MediumBlue, Text to "Settings" and name it settingsButton. Set FlatAppearance.MouseOverBackColor to LightBlue and Cursor to Hand.
+ Copy the settings button and rename it rigolScopeButton, set Text to "Rigol SDS1104X-E DSO".

Create user controls.
+ Right-click Project -> Add -> User Control (Windows Forms), naming it SettingsControl.
+ Check MainView splitContainer1 size, it should be 784,389; left pane being 240 the user control should be 540,389.
+ Right-click Project -> Add -> User Control (Windows Forms), naming it RigolScopeControl.

Add code to MainView.cs to switch views.

```csharp
    private void ShowView(UserControl newView)
    {
        splitContainer1.Panel2.Controls.Clear();
        newView.Dock = DockStyle.Fill;
        splitContainer1.Panel2.Controls.Add(newView);
    }

    private void settingsButton_Click(object sender, EventArgs e)
    {
        ShowView(new SettingsControl());
    }

    private void rigolScopebutton_Click(object sender, EventArgs e)
    {
        ShowView(new RigolScopeControl());
    }
```

Because these user controls are not persisted when switching views, the user
controls will have to update themselves from the settings when loaded.

To make that more efficient, a data model for settings can be held in memory.

Create a settings class, AppSettings.cs to use to persist settings in memory.

```csharp
public class AppSettings
{
    public string RigolScopeIp {get; set;} = "192.168.50.164";
}
```

Next create a class to load and save these settings.

```csharp
using System;
using System.IO;
using System.Text.Json;

public static class SettingsManager
{
    private static readonly string SettingsFilePath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
    public static AppSettings Settings { get; private set; } = new AppSettings();

    public static void LoadSettings()
    {
        if (File.Exists(SettingsFilePath))
        {
            try
            {
                string json = File.ReadAllText(SettingsFilePath);
                Settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }
        }
    }

    public static void SaveSettings()
    {
        try
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Settings, options);
            File.WriteAllText(SettingsFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving settings: {ex.Message}");
        }
    }
}
```

Now in Program.cs at application startup load the settings.

```csharp
static void Main()
{
    SettingsManager.LoadSettings();
    {rest of Main code follows}
}
```

And update MainView.cs with a new method, MainForm_FormClosing as follows.

```csharp
    public MainView()
    {
        InitializeComponent();
        this.Text = "WinFormsApp1";
        this.FormClosing += MainForm_FormClosing;
    }
    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        SettingsManager.SaveSettings();
    }
```

Now SettingsControl.cs can update the UI from SettingsManager when loaded and save changes in memory.

```csharp
    public SettingsControl()
    {
        InitializeComponent();
        this.Load += MyUserControl_Load;
    }
    
    private void MyUserControl_Load(object? sender, EventArgs e)
    {
        rigolScopeIpTextBox.Text = SettingsManager.Settings.RigolScopeIp;
    }
    public void UpdateSettingsInMemoryFromUi()
    {
        SettingsManager.Settings.RigolScopeIp = rigolScopeIpTextBox.Text;
    }
```

Updating the MainView from the user controls.
Create a folder Events and in it a class StatusChangedEventArgs.cs.
Create a folder Interfaces and in it a class IStatusProvider.cs.
In MainView, set the 


Then in a user control where needed add this, with the handler set as default to an empty delegate { } so that
it is optional. The StatusChanged? line below can be placed where needed to update MainView from the user control. Note that IStatusProvider was added to SettingsControl.

```csharp
public partial class SettingsControl : UserControl, IStatusProvider

public event EventHandler<StatusChangedEventArgs> StatusChanged = (sender, e) => { };

StatusChanged?.Invoke(this, new StatusChangedEventArgs($"Settings loaded from \"{SettingsFilePath}\".", true));
```

The bool IsBusy is passed back with status text so that MainView to synchronize user control initiated actions
such as instrument I/O with user control enable/disable. 

## Risks
To exit the application or if a user control is busy, we might have a problem. It may well be necessary to have a
notifier that goes from MainView to the user control to interrupt some long operation, if the user wants to stop
the operation or exit the program.
