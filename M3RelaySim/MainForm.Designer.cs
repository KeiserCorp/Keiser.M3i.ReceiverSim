namespace Keiser.M3i.ReceiverSimulator
{
    partial class MainForm
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
            relay.stop();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarCurrentState = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarClearButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarSaveButton = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlsContainerPanel = new System.Windows.Forms.Panel();
            this.threadToggleButton = new System.Windows.Forms.Button();
            this.broadcastContainerPanel = new System.Windows.Forms.Panel();
            this.portBox = new System.Windows.Forms.TextBox();
            this.numOfBikesNumeric = new System.Windows.Forms.NumericUpDown();
            this.portBoxLabel = new System.Windows.Forms.Label();
            this.numOfBikesLabel = new System.Windows.Forms.Label();
            this.ipAddressBox = new System.Windows.Forms.TextBox();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.transAttPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uuidSendCheckbox = new System.Windows.Forms.CheckBox();
            this.versionSendCheckbox = new System.Windows.Forms.CheckBox();
            this.intervalSendCheckbox = new System.Windows.Forms.CheckBox();
            this.imperialUnitsCheckbox = new System.Windows.Forms.CheckBox();
            this.rssiSendCheckbox = new System.Windows.Forms.CheckBox();
            this.randomIdCheckbox = new System.Windows.Forms.CheckBox();
            this.realWorldCheckBox = new System.Windows.Forms.CheckBox();
            this.GearBox = new System.Windows.Forms.CheckBox();
            this.outputBox = new System.Windows.Forms.ListBox();
            this.statusBar.SuspendLayout();
            this.controlsContainerPanel.SuspendLayout();
            this.broadcastContainerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfBikesNumeric)).BeginInit();
            this.transAttPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarCurrentState,
            this.errorStatus,
            this.toolStripStatusLabel1,
            this.statusBarClearButton,
            this.statusBarSaveButton});
            this.statusBar.Location = new System.Drawing.Point(0, 356);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(868, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Status Bar";
            // 
            // statusBarCurrentState
            // 
            this.statusBarCurrentState.AutoSize = false;
            this.statusBarCurrentState.BackColor = System.Drawing.SystemColors.Control;
            this.statusBarCurrentState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarCurrentState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarCurrentState.ForeColor = System.Drawing.Color.White;
            this.statusBarCurrentState.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.statusBarCurrentState.Name = "statusBarCurrentState";
            this.statusBarCurrentState.Size = new System.Drawing.Size(65, 17);
            // 
            // errorStatus
            // 
            this.errorStatus.AutoSize = false;
            this.errorStatus.BackColor = System.Drawing.SystemColors.Control;
            this.errorStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.errorStatus.ForeColor = System.Drawing.Color.Red;
            this.errorStatus.Name = "errorStatus";
            this.errorStatus.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.errorStatus.Size = new System.Drawing.Size(663, 17);
            this.errorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 15, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusBarClearButton
            // 
            this.statusBarClearButton.AutoSize = false;
            this.statusBarClearButton.BackColor = System.Drawing.SystemColors.Control;
            this.statusBarClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusBarClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBarClearButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.statusBarClearButton.Name = "statusBarClearButton";
            this.statusBarClearButton.Size = new System.Drawing.Size(17, 17);
            this.statusBarClearButton.Text = "statusBarClearButton";
            this.statusBarClearButton.Click += new System.EventHandler(this.statusBarClearButton_Click);
            // 
            // statusBarSaveButton
            // 
            this.statusBarSaveButton.AutoSize = false;
            this.statusBarSaveButton.BackColor = System.Drawing.SystemColors.Control;
            this.statusBarSaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusBarSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusBarSaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusBarSaveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.statusBarSaveButton.Name = "statusBarSaveButton";
            this.statusBarSaveButton.Size = new System.Drawing.Size(16, 17);
            this.statusBarSaveButton.Text = "statusBarSaveButton";
            this.statusBarSaveButton.Click += new System.EventHandler(this.statusBarSaveButton_Click);
            // 
            // controlsContainerPanel
            // 
            this.controlsContainerPanel.Controls.Add(this.threadToggleButton);
            this.controlsContainerPanel.Controls.Add(this.broadcastContainerPanel);
            this.controlsContainerPanel.Controls.Add(this.transAttPanel);
            this.controlsContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsContainerPanel.Name = "controlsContainerPanel";
            this.controlsContainerPanel.Size = new System.Drawing.Size(124, 354);
            this.controlsContainerPanel.TabIndex = 1;
            // 
            // threadToggleButton
            // 
            this.threadToggleButton.Location = new System.Drawing.Point(3, 325);
            this.threadToggleButton.Name = "threadToggleButton";
            this.threadToggleButton.Size = new System.Drawing.Size(75, 23);
            this.threadToggleButton.TabIndex = 3;
            this.threadToggleButton.UseVisualStyleBackColor = true;
            this.threadToggleButton.Click += new System.EventHandler(this.threadToggleButton_Click);
            // 
            // broadcastContainerPanel
            // 
            this.broadcastContainerPanel.Controls.Add(this.portBox);
            this.broadcastContainerPanel.Controls.Add(this.numOfBikesNumeric);
            this.broadcastContainerPanel.Controls.Add(this.portBoxLabel);
            this.broadcastContainerPanel.Controls.Add(this.numOfBikesLabel);
            this.broadcastContainerPanel.Controls.Add(this.ipAddressBox);
            this.broadcastContainerPanel.Controls.Add(this.ipAddressLabel);
            this.broadcastContainerPanel.Location = new System.Drawing.Point(1, 4);
            this.broadcastContainerPanel.Name = "broadcastContainerPanel";
            this.broadcastContainerPanel.Size = new System.Drawing.Size(116, 124);
            this.broadcastContainerPanel.TabIndex = 3;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(6, 98);
            this.portBox.MaxLength = 5;
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(106, 20);
            this.portBox.TabIndex = 2;
            this.portBox.Text = "35680";
            this.portBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portBox_KeyPress);
            this.portBox.Validating += new System.ComponentModel.CancelEventHandler(this.portBox_Validating);
            // 
            // numOfBikesNumeric
            // 
            this.numOfBikesNumeric.Location = new System.Drawing.Point(6, 20);
            this.numOfBikesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOfBikesNumeric.Name = "numOfBikesNumeric";
            this.numOfBikesNumeric.Size = new System.Drawing.Size(106, 20);
            this.numOfBikesNumeric.TabIndex = 1;
            this.numOfBikesNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // portBoxLabel
            // 
            this.portBoxLabel.AutoSize = true;
            this.portBoxLabel.Location = new System.Drawing.Point(3, 82);
            this.portBoxLabel.Name = "portBoxLabel";
            this.portBoxLabel.Size = new System.Drawing.Size(77, 13);
            this.portBoxLabel.TabIndex = 0;
            this.portBoxLabel.Text = "Broadcast Port";
            // 
            // numOfBikesLabel
            // 
            this.numOfBikesLabel.AutoSize = true;
            this.numOfBikesLabel.Location = new System.Drawing.Point(3, 4);
            this.numOfBikesLabel.Name = "numOfBikesLabel";
            this.numOfBikesLabel.Size = new System.Drawing.Size(84, 13);
            this.numOfBikesLabel.TabIndex = 0;
            this.numOfBikesLabel.Text = "Number of bikes";
            // 
            // ipAddressBox
            // 
            this.ipAddressBox.Location = new System.Drawing.Point(6, 59);
            this.ipAddressBox.MaxLength = 15;
            this.ipAddressBox.Name = "ipAddressBox";
            this.ipAddressBox.Size = new System.Drawing.Size(106, 20);
            this.ipAddressBox.TabIndex = 1;
            this.ipAddressBox.Text = "239.10.10.10";
            this.ipAddressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ipAddressBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ipAddressBox_KeyPress);
            this.ipAddressBox.Validating += new System.ComponentModel.CancelEventHandler(this.ipAddressBox_Validating);
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(3, 43);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(109, 13);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "Broadcast IP Address";
            // 
            // transAttPanel
            // 
            this.transAttPanel.Controls.Add(this.uuidSendCheckbox);
            this.transAttPanel.Controls.Add(this.versionSendCheckbox);
            this.transAttPanel.Controls.Add(this.intervalSendCheckbox);
            this.transAttPanel.Controls.Add(this.imperialUnitsCheckbox);
            this.transAttPanel.Controls.Add(this.rssiSendCheckbox);
            this.transAttPanel.Controls.Add(this.randomIdCheckbox);
            this.transAttPanel.Controls.Add(this.realWorldCheckBox);
            this.transAttPanel.Controls.Add(this.GearBox);
            this.transAttPanel.Location = new System.Drawing.Point(7, 133);
            this.transAttPanel.Name = "transAttPanel";
            this.transAttPanel.Size = new System.Drawing.Size(110, 186);
            this.transAttPanel.TabIndex = 2;
            // 
            // uuidSendCheckbox
            // 
            this.uuidSendCheckbox.AutoSize = true;
            this.uuidSendCheckbox.Checked = true;
            this.uuidSendCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uuidSendCheckbox.Location = new System.Drawing.Point(3, 3);
            this.uuidSendCheckbox.Name = "uuidSendCheckbox";
            this.uuidSendCheckbox.Size = new System.Drawing.Size(81, 17);
            this.uuidSendCheckbox.TabIndex = 0;
            this.uuidSendCheckbox.Text = "UUID Send";
            this.uuidSendCheckbox.UseVisualStyleBackColor = true;
            // 
            // versionSendCheckbox
            // 
            this.versionSendCheckbox.AutoSize = true;
            this.versionSendCheckbox.Checked = true;
            this.versionSendCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.versionSendCheckbox.Location = new System.Drawing.Point(3, 26);
            this.versionSendCheckbox.Name = "versionSendCheckbox";
            this.versionSendCheckbox.Size = new System.Drawing.Size(89, 17);
            this.versionSendCheckbox.TabIndex = 1;
            this.versionSendCheckbox.Text = "Version Send";
            this.versionSendCheckbox.UseVisualStyleBackColor = true;
            // 
            // intervalSendCheckbox
            // 
            this.intervalSendCheckbox.AutoSize = true;
            this.intervalSendCheckbox.Checked = true;
            this.intervalSendCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.intervalSendCheckbox.Location = new System.Drawing.Point(3, 49);
            this.intervalSendCheckbox.Name = "intervalSendCheckbox";
            this.intervalSendCheckbox.Size = new System.Drawing.Size(89, 17);
            this.intervalSendCheckbox.TabIndex = 2;
            this.intervalSendCheckbox.Text = "Interval Send";
            this.intervalSendCheckbox.UseVisualStyleBackColor = true;
            // 
            // imperialUnitsCheckbox
            // 
            this.imperialUnitsCheckbox.AutoSize = true;
            this.imperialUnitsCheckbox.Checked = true;
            this.imperialUnitsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imperialUnitsCheckbox.Location = new System.Drawing.Point(3, 72);
            this.imperialUnitsCheckbox.Name = "imperialUnitsCheckbox";
            this.imperialUnitsCheckbox.Size = new System.Drawing.Size(89, 17);
            this.imperialUnitsCheckbox.TabIndex = 4;
            this.imperialUnitsCheckbox.Text = "Imperial Units";
            this.imperialUnitsCheckbox.UseVisualStyleBackColor = true;
            // 
            // rssiSendCheckbox
            // 
            this.rssiSendCheckbox.AutoSize = true;
            this.rssiSendCheckbox.Checked = true;
            this.rssiSendCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rssiSendCheckbox.Location = new System.Drawing.Point(3, 95);
            this.rssiSendCheckbox.Name = "rssiSendCheckbox";
            this.rssiSendCheckbox.Size = new System.Drawing.Size(79, 17);
            this.rssiSendCheckbox.TabIndex = 5;
            this.rssiSendCheckbox.Text = "RSSI Send";
            this.rssiSendCheckbox.UseVisualStyleBackColor = true;
            // 
            // randomIdCheckbox
            // 
            this.randomIdCheckbox.AutoSize = true;
            this.randomIdCheckbox.Checked = true;
            this.randomIdCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomIdCheckbox.Location = new System.Drawing.Point(3, 118);
            this.randomIdCheckbox.Name = "randomIdCheckbox";
            this.randomIdCheckbox.Size = new System.Drawing.Size(85, 17);
            this.randomIdCheckbox.TabIndex = 6;
            this.randomIdCheckbox.Text = "Random IDs";
            this.randomIdCheckbox.UseVisualStyleBackColor = true;
            // 
            // realWorldCheckBox
            // 
            this.realWorldCheckBox.AutoSize = true;
            this.realWorldCheckBox.Checked = true;
            this.realWorldCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.realWorldCheckBox.Location = new System.Drawing.Point(3, 141);
            this.realWorldCheckBox.Name = "realWorldCheckBox";
            this.realWorldCheckBox.Size = new System.Drawing.Size(79, 17);
            this.realWorldCheckBox.TabIndex = 7;
            this.realWorldCheckBox.Text = "Real World";
            this.realWorldCheckBox.UseVisualStyleBackColor = true;
            // 
            // GearBox
            // 
            this.GearBox.AutoSize = true;
            this.GearBox.Checked = true;
            this.GearBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GearBox.Location = new System.Drawing.Point(3, 164);
            this.GearBox.Name = "GearBox";
            this.GearBox.Size = new System.Drawing.Size(77, 17);
            this.GearBox.TabIndex = 8;
            this.GearBox.Text = "Gear Send";
            this.GearBox.UseVisualStyleBackColor = true;
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.Menu;
            this.outputBox.CausesValidation = false;
            this.outputBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.FormattingEnabled = true;
            this.outputBox.ItemHeight = 11;
            this.outputBox.Location = new System.Drawing.Point(123, 0);
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollAlwaysVisible = true;
            this.outputBox.Size = new System.Drawing.Size(745, 356);
            this.outputBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(868, 378);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.controlsContainerPanel);
            this.Controls.Add(this.statusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "M3i Receiver Simulator [v1.1]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.controlsContainerPanel.ResumeLayout(false);
            this.broadcastContainerPanel.ResumeLayout(false);
            this.broadcastContainerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfBikesNumeric)).EndInit();
            this.transAttPanel.ResumeLayout(false);
            this.transAttPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarCurrentState;
        private System.Windows.Forms.Panel controlsContainerPanel;
        private System.Windows.Forms.Label numOfBikesLabel;
        private System.Windows.Forms.NumericUpDown numOfBikesNumeric;
        private System.Windows.Forms.FlowLayoutPanel transAttPanel;
        private System.Windows.Forms.CheckBox uuidSendCheckbox;
        private System.Windows.Forms.CheckBox versionSendCheckbox;
        private System.Windows.Forms.CheckBox intervalSendCheckbox;
        private System.Windows.Forms.CheckBox imperialUnitsCheckbox;
        private System.Windows.Forms.CheckBox rssiSendCheckbox;
        private System.Windows.Forms.ListBox outputBox;
        private System.Windows.Forms.Panel broadcastContainerPanel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.TextBox ipAddressBox;
        private System.Windows.Forms.Label portBoxLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.ToolStripStatusLabel errorStatus;
        private System.Windows.Forms.Button threadToggleButton;
        private System.Windows.Forms.ToolStripStatusLabel statusBarSaveButton;
        private System.Windows.Forms.ToolStripStatusLabel statusBarClearButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox randomIdCheckbox;
        private System.Windows.Forms.CheckBox realWorldCheckBox;
        private System.Windows.Forms.CheckBox GearBox;

    }
}

