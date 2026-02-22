namespace WinFormsApp1
{
    partial class SettingsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rigolScopeIpTextBox = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            saveSettingsButton = new Button();
            resetSettingsButton = new Button();
            loadSettingsButton = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // rigolScopeIpTextBox
            // 
            rigolScopeIpTextBox.Location = new Point(85, 28);
            rigolScopeIpTextBox.Name = "rigolScopeIpTextBox";
            rigolScopeIpTextBox.Size = new Size(100, 23);
            rigolScopeIpTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "IP Address";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(rigolScopeIpTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(3, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(206, 92);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rigol SDS1104X-E";
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Location = new Point(409, 363);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(128, 23);
            saveSettingsButton.TabIndex = 4;
            saveSettingsButton.Text = "Save";
            saveSettingsButton.UseVisualStyleBackColor = true;
            saveSettingsButton.Click += saveSettingsButton_Click;
            // 
            // resetSettingsButton
            // 
            resetSettingsButton.Location = new Point(409, 305);
            resetSettingsButton.Name = "resetSettingsButton";
            resetSettingsButton.Size = new Size(128, 23);
            resetSettingsButton.TabIndex = 5;
            resetSettingsButton.Text = "Reset";
            resetSettingsButton.UseVisualStyleBackColor = true;
            resetSettingsButton.Click += resetSettingsButton_Click;
            // 
            // loadSettingsButton
            // 
            loadSettingsButton.Location = new Point(409, 334);
            loadSettingsButton.Name = "loadSettingsButton";
            loadSettingsButton.Size = new Size(128, 23);
            loadSettingsButton.TabIndex = 6;
            loadSettingsButton.Text = "Load";
            loadSettingsButton.UseVisualStyleBackColor = true;
            loadSettingsButton.Click += loadSettingsButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MediumBlue;
            label2.Location = new Point(225, 11);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 7;
            label2.Text = "Settings";
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(loadSettingsButton);
            Controls.Add(resetSettingsButton);
            Controls.Add(saveSettingsButton);
            Controls.Add(groupBox1);
            Name = "SettingsControl";
            Size = new Size(540, 389);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox rigolScopeIpTextBox;
        private Label label1;
        private GroupBox groupBox1;
        private Button saveSettingsButton;
        private Button resetSettingsButton;
        private Button loadSettingsButton;
        private Label label2;
    }
}
