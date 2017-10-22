namespace Lego
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.cmd7 = new System.Windows.Forms.Button();
            this.cmd8 = new System.Windows.Forms.Button();
            this.cmd9 = new System.Windows.Forms.Button();
            this.cmd4 = new System.Windows.Forms.Button();
            this.cmd5 = new System.Windows.Forms.Button();
            this.cmd6 = new System.Windows.Forms.Button();
            this.cmd1 = new System.Windows.Forms.Button();
            this.cmd2 = new System.Windows.Forms.Button();
            this.cmd3 = new System.Windows.Forms.Button();
            this.cmd0 = new System.Windows.Forms.Button();
            this.trackBarPower = new System.Windows.Forms.TrackBar();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnLightOff = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(120, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(204, 13);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(78, 23);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cmd7
            // 
            this.cmd7.Enabled = false;
            this.cmd7.Location = new System.Drawing.Point(26, 110);
            this.cmd7.Name = "cmd7";
            this.cmd7.Size = new System.Drawing.Size(75, 75);
            this.cmd7.TabIndex = 5;
            this.cmd7.Tag = "7";
            this.cmd7.Text = "&7";
            this.cmd7.UseVisualStyleBackColor = true;
            this.cmd7.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd8
            // 
            this.cmd8.Enabled = false;
            this.cmd8.Location = new System.Drawing.Point(107, 110);
            this.cmd8.Name = "cmd8";
            this.cmd8.Size = new System.Drawing.Size(75, 75);
            this.cmd8.TabIndex = 6;
            this.cmd8.Tag = "8";
            this.cmd8.Text = "&8";
            this.cmd8.UseVisualStyleBackColor = true;
            this.cmd8.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd9
            // 
            this.cmd9.Enabled = false;
            this.cmd9.Location = new System.Drawing.Point(188, 110);
            this.cmd9.Name = "cmd9";
            this.cmd9.Size = new System.Drawing.Size(75, 75);
            this.cmd9.TabIndex = 7;
            this.cmd9.Tag = "9";
            this.cmd9.Text = "&9";
            this.cmd9.UseVisualStyleBackColor = true;
            this.cmd9.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd4
            // 
            this.cmd4.Enabled = false;
            this.cmd4.Location = new System.Drawing.Point(26, 191);
            this.cmd4.Name = "cmd4";
            this.cmd4.Size = new System.Drawing.Size(75, 75);
            this.cmd4.TabIndex = 8;
            this.cmd4.Tag = "4";
            this.cmd4.Text = "&4";
            this.cmd4.UseVisualStyleBackColor = true;
            this.cmd4.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd5
            // 
            this.cmd5.Enabled = false;
            this.cmd5.Location = new System.Drawing.Point(107, 191);
            this.cmd5.Name = "cmd5";
            this.cmd5.Size = new System.Drawing.Size(75, 75);
            this.cmd5.TabIndex = 9;
            this.cmd5.Tag = "5";
            this.cmd5.Text = "&5";
            this.cmd5.UseVisualStyleBackColor = true;
            this.cmd5.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd6
            // 
            this.cmd6.Enabled = false;
            this.cmd6.Location = new System.Drawing.Point(188, 191);
            this.cmd6.Name = "cmd6";
            this.cmd6.Size = new System.Drawing.Size(75, 75);
            this.cmd6.TabIndex = 10;
            this.cmd6.Tag = "6";
            this.cmd6.Text = "&6";
            this.cmd6.UseVisualStyleBackColor = true;
            this.cmd6.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd1
            // 
            this.cmd1.Enabled = false;
            this.cmd1.Location = new System.Drawing.Point(26, 272);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(75, 75);
            this.cmd1.TabIndex = 11;
            this.cmd1.Tag = "1";
            this.cmd1.Text = "&1";
            this.cmd1.UseVisualStyleBackColor = true;
            this.cmd1.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd2
            // 
            this.cmd2.Enabled = false;
            this.cmd2.Location = new System.Drawing.Point(107, 272);
            this.cmd2.Name = "cmd2";
            this.cmd2.Size = new System.Drawing.Size(75, 75);
            this.cmd2.TabIndex = 12;
            this.cmd2.Tag = "2";
            this.cmd2.Text = "&2";
            this.cmd2.UseVisualStyleBackColor = true;
            this.cmd2.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd3
            // 
            this.cmd3.Enabled = false;
            this.cmd3.Location = new System.Drawing.Point(188, 272);
            this.cmd3.Name = "cmd3";
            this.cmd3.Size = new System.Drawing.Size(75, 75);
            this.cmd3.TabIndex = 13;
            this.cmd3.Tag = "3";
            this.cmd3.Text = "&3";
            this.cmd3.UseVisualStyleBackColor = true;
            this.cmd3.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cmd0
            // 
            this.cmd0.Enabled = false;
            this.cmd0.Location = new System.Drawing.Point(26, 353);
            this.cmd0.Name = "cmd0";
            this.cmd0.Size = new System.Drawing.Size(237, 75);
            this.cmd0.TabIndex = 14;
            this.cmd0.Tag = "0";
            this.cmd0.Text = "&0";
            this.cmd0.UseVisualStyleBackColor = true;
            this.cmd0.Click += new System.EventHandler(this.cmd_Click);
            // 
            // trackBarPower
            // 
            this.trackBarPower.LargeChange = 10;
            this.trackBarPower.Location = new System.Drawing.Point(26, 45);
            this.trackBarPower.Maximum = 100;
            this.trackBarPower.Name = "trackBarPower";
            this.trackBarPower.Size = new System.Drawing.Size(237, 45);
            this.trackBarPower.TabIndex = 15;
            this.trackBarPower.TickFrequency = 10;
            this.trackBarPower.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarPower.Value = 50;
            this.trackBarPower.ValueChanged += new System.EventHandler(this.trackBarPower_ValueChanged);
            // 
            // btnRed
            // 
            this.btnRed.Location = new System.Drawing.Point(26, 434);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(75, 75);
            this.btnRed.TabIndex = 16;
            this.btnRed.Text = "Red";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.Location = new System.Drawing.Point(107, 434);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(75, 75);
            this.btnGreen.TabIndex = 17;
            this.btnGreen.Text = "Green";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(188, 434);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(75, 75);
            this.btnBlue.TabIndex = 18;
            this.btnBlue.Text = "Blue";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnLightOff
            // 
            this.btnLightOff.Location = new System.Drawing.Point(26, 515);
            this.btnLightOff.Name = "btnLightOff";
            this.btnLightOff.Size = new System.Drawing.Size(237, 75);
            this.btnLightOff.TabIndex = 19;
            this.btnLightOff.Text = "Off";
            this.btnLightOff.UseVisualStyleBackColor = true;
            this.btnLightOff.Click += new System.EventHandler(this.btnLightOff_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(13, 14);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPort.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 599);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.btnLightOff);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.trackBarPower);
            this.Controls.Add(this.cmd0);
            this.Controls.Add(this.cmd3);
            this.Controls.Add(this.cmd2);
            this.Controls.Add(this.cmd1);
            this.Controls.Add(this.cmd6);
            this.Controls.Add(this.cmd5);
            this.Controls.Add(this.cmd4);
            this.Controls.Add(this.cmd9);
            this.Controls.Add(this.cmd8);
            this.Controls.Add(this.cmd7);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "NXT Remote Control";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button cmd7;
        private System.Windows.Forms.Button cmd8;
        private System.Windows.Forms.Button cmd9;
        private System.Windows.Forms.Button cmd4;
        private System.Windows.Forms.Button cmd5;
        private System.Windows.Forms.Button cmd6;
        private System.Windows.Forms.Button cmd1;
        private System.Windows.Forms.Button cmd2;
        private System.Windows.Forms.Button cmd3;
        private System.Windows.Forms.Button cmd0;
        private System.Windows.Forms.TrackBar trackBarPower;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnLightOff;
        private System.Windows.Forms.ComboBox comboBoxPort;
    }
}

