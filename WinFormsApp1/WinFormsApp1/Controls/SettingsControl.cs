using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class SettingsControl : UserControl, IStatusProvider
{
    public event EventHandler<StatusChangedEventArgs> StatusChanged = (sender, e) => { };

    public SettingsControl()
    {
        InitializeComponent();
        this.Load += MyUserControl_Load;
    }

    private void UpdateUiFromSettingsInMemory()
    {
        rigolScopeIpTextBox.Text = SettingsManager.Settings.RigolScopeIp;
    }
    private void MyUserControl_Load(object? sender, EventArgs e)
    {
        UpdateUiFromSettingsInMemory();
    }
    public void UpdateSettingsInMemoryFromUi()
    {
        if (rigolScopeIpTextBox.Text != SettingsManager.Settings.RigolScopeIp)
        {
            SettingsManager.Settings.RigolScopeIp = rigolScopeIpTextBox.Text;
            SettingsManager.Settings.SettingsChanged = true;
        }

    }
    private void resetSettingsButton_Click(object sender, EventArgs e)
    {
        SettingsManager.Settings = new AppSettings();
        UpdateUiFromSettingsInMemory();
        StatusChanged?.Invoke(this, new StatusChangedEventArgs("Settings reset to default.", false));
    }

    private void loadSettingsButton_Click(object sender, EventArgs e)
    {
        string SettingsFilePath = SettingsManager.LoadSettings();
        if (SettingsFilePath != null)
        {
            UpdateUiFromSettingsInMemory();
            StatusChanged?.Invoke(this, new StatusChangedEventArgs($"Settings loaded from \"{SettingsFilePath}\".", false));
        }
        else
        {
            StatusChanged?.Invoke(this, new StatusChangedEventArgs("Load settings failed.", false));
        }
    }

    private void saveSettingsButton_Click(object sender, EventArgs e)
    {
        UpdateSettingsInMemoryFromUi();
        string SettingsFilePath = SettingsManager.SaveSettings();
        if (SettingsFilePath != null)
        {
            StatusChanged?.Invoke(this, new StatusChangedEventArgs($"Settings saved to \"{SettingsFilePath}\".", false));
        }
        else
        {
            StatusChanged?.Invoke(this, new StatusChangedEventArgs("Save settings failed.", false));
        }
    }
}
