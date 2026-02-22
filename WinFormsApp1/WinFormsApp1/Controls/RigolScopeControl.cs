using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class RigolScopeControl : UserControl, IStatusProvider
    {
        private bool _isBusy = false;
        public event EventHandler<StatusChangedEventArgs> StatusChanged = (sender, e) => { };
        public RigolScopeControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            _isBusy = _isBusy ? false : true;

            // TODO: Communicate with the scope, refreshing some data
            if (_isBusy)
            {
                StatusChanged?.Invoke(this, new StatusChangedEventArgs("Start talking to Rigol Scope.", true));
            }
            else
            {
                StatusChanged?.Invoke(this, new StatusChangedEventArgs("Finished talking to Rigol Scope.", false));

            }
        }
    }
}
