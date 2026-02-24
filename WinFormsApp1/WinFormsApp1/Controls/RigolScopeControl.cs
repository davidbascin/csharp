using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Hardware;

namespace WinFormsApp1
{
    public partial class RigolScopeControl : UserControl, IStatusProvider
    {
        public event EventHandler<StatusChangedEventArgs> StatusChanged = (sender, e) => { };
        private RigolScopeHardware ScopeHw = new RigolScopeHardware();
        public RigolScopeControl()
        {
            InitializeComponent();
            ScopeHw.StatusChanged += ScopeHwStatusChanged;
            Disposed += (_, _) => ScopeHw.StatusChanged -= ScopeHwStatusChanged;
        }
        private void ScopeHwStatusChanged(object? sender, StatusChangedEventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            string response = ScopeHw.Query("*IDN?", 5000, 100);
        }
    }
}
