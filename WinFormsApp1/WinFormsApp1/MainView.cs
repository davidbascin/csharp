namespace WinFormsApp1;
using System.Threading.Tasks;

public partial class MainView : Form
{
    // TODO: Check if _isBusy too long and force abort as a feature
    private bool _isBusy = false; 
    public MainView()
    {
        InitializeComponent();
        this.Text = "WinFormsApp1";
        this.FormClosing += MainForm_FormClosing;
        // Second status text used as a busy indicator on the far right.
        toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
        toolStripStatusLabel2.Spring = true;
        toolStripStatusLabel2.Text = "";
    }
    public void SaveSettings()
    {
        if (splitContainer1.Panel2.Controls.Count > 0)
        {
            if (splitContainer1.Panel2.Controls[0] is SettingsControl settingsControl)
            {
                settingsControl.UpdateSettingsInMemoryFromUi();
            }
        }
        string SettingsFilePath = SettingsManager.SaveSettings();
        if (SettingsFilePath != null)
        {
            this.statusStrip1.Items[0].Text = $"Settings saved to \"{SettingsFilePath}\"";
        }
    }
    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // TODO: If some I/O or other operation is ongoing, terminate it first.
    }
    private void ShowView(UserControl newView)
    {
        // to prevent memory leaks, unsubscribe from the old control's events before removing it
        if (splitContainer1.Panel2.Controls is IStatusProvider splitStatusControl)
        {
            splitStatusControl.StatusChanged -= OnControlStatusChanged;
        }
        splitContainer1.Panel2.Controls.Clear();
        newView.Dock = DockStyle.Fill;
        if (newView is IStatusProvider statusControl)
        {
            statusControl.StatusChanged += OnControlStatusChanged;
        }
        splitContainer1.Panel2.Controls.Add(newView);
    }
    private void OnControlStatusChanged(object? sender, StatusChangedEventArgs e)
    {
        statusStrip1.Items[0].Text = e.StatusMessage;
        _isBusy = e.IsBusy;
        if (_isBusy)
        {
            settingsButton.Enabled = false;
            rigolScopebutton.Enabled = false;
            toolStripStatusLabel2.Text = "BUSY";
        }
        else
        {
            settingsButton.Enabled = true;
            rigolScopebutton.Enabled = true;
            toolStripStatusLabel2.Text = "";
        }
    }
    private void settingsButton_Click(object sender, EventArgs e)
    {
        ShowView(new SettingsControl());
    }

    private void rigolScopebutton_Click(object sender, EventArgs e)
    {
        ShowView(new RigolScopeControl());
    }

    private async void toolStripStatusLabel1_Click(object sender, EventArgs e)
    {
        if (sender is ToolStripItem item && !string.IsNullOrEmpty(item.Text))
        {
            var label = sender as ToolStripStatusLabel;
            if (label == null || string.IsNullOrWhiteSpace(label.Text)) return;

            string source = label.Text;
            label.Text = "Copied to clipboard.";
            string result = source; // Default to the full string

            int firstQuote = source.IndexOf('"');
            int lastQuote = source.LastIndexOf('"');

            // Only extract if there are at least two distinct double-quote characters
            if (firstQuote != -1 && lastQuote != -1 && firstQuote < lastQuote)
            {
                // Extract everything between the first and last quote, inclusive
                result = source.Substring(firstQuote, (lastQuote - firstQuote) + 1);
            }

            // Set the clipboard text to either the extracted segment or the full string
            Clipboard.SetText(result);
            await Task.Delay(500);
            label.Text = source;
        }
    }
}
