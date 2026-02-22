namespace WinFormsApp1
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            rigolScopebutton = new Button();
            settingsButton = new Button();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(784, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.DoubleClickEnabled = true;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(42, 17);
            toolStripStatusLabel1.Text = "Ready.";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ForeColor = Color.Red;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(35, 17);
            toolStripStatusLabel2.Text = "BUSY";
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Gainsboro;
            splitContainer1.Panel1.Controls.Add(rigolScopebutton);
            splitContainer1.Panel1.Controls.Add(settingsButton);
            splitContainer1.Size = new Size(784, 389);
            splitContainer1.SplitterDistance = 240;
            splitContainer1.TabIndex = 2;
            // 
            // rigolScopebutton
            // 
            rigolScopebutton.Cursor = Cursors.Hand;
            rigolScopebutton.FlatAppearance.BorderSize = 0;
            rigolScopebutton.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            rigolScopebutton.FlatStyle = FlatStyle.Flat;
            rigolScopebutton.ForeColor = Color.MediumBlue;
            rigolScopebutton.Location = new Point(12, 101);
            rigolScopebutton.Name = "rigolScopebutton";
            rigolScopebutton.Size = new Size(220, 23);
            rigolScopebutton.TabIndex = 1;
            rigolScopebutton.Text = "Rigol SDS1104X-E DSO";
            rigolScopebutton.UseVisualStyleBackColor = true;
            rigolScopebutton.Click += rigolScopebutton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Cursor = Cursors.Hand;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = Color.MediumBlue;
            settingsButton.Location = new Point(12, 176);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(220, 23);
            settingsButton.TabIndex = 0;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Margin = new Padding(2);
            Name = "MainView";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private Button rigolScopebutton;
        private Button settingsButton;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}
