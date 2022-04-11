namespace modestGieikCleaner
{
    partial class AppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.RadioBoxCleanAll = new System.Windows.Forms.RadioButton();
            this.RadioBoxHDD = new System.Windows.Forms.RadioButton();
            this.RadioBoxMAC = new System.Windows.Forms.RadioButton();
            this.RadioBoxBIOS = new System.Windows.Forms.RadioButton();
            this.RadioBoxHKeys = new System.Windows.Forms.RadioButton();
            this.RadioBoxTracers = new System.Windows.Forms.RadioButton();
            this.btnExecute = new System.Windows.Forms.Button();
            this.fakeConsole = new System.Windows.Forms.RichTextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.RadioBoxCleanAll);
            this.optionsPanel.Controls.Add(this.RadioBoxHDD);
            this.optionsPanel.Controls.Add(this.RadioBoxMAC);
            this.optionsPanel.Controls.Add(this.RadioBoxBIOS);
            this.optionsPanel.Controls.Add(this.RadioBoxHKeys);
            this.optionsPanel.Controls.Add(this.RadioBoxTracers);
            this.optionsPanel.Location = new System.Drawing.Point(14, 167);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(197, 208);
            this.optionsPanel.TabIndex = 1;
            // 
            // RadioBoxCleanAll
            // 
            this.RadioBoxCleanAll.AutoSize = true;
            this.RadioBoxCleanAll.Checked = true;
            this.RadioBoxCleanAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxCleanAll.Location = new System.Drawing.Point(12, 167);
            this.RadioBoxCleanAll.Name = "RadioBoxCleanAll";
            this.RadioBoxCleanAll.Size = new System.Drawing.Size(83, 22);
            this.RadioBoxCleanAll.TabIndex = 18;
            this.RadioBoxCleanAll.TabStop = true;
            this.RadioBoxCleanAll.Text = "Clean All";
            this.RadioBoxCleanAll.UseVisualStyleBackColor = true;
            // 
            // RadioBoxHDD
            // 
            this.RadioBoxHDD.AutoSize = true;
            this.RadioBoxHDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxHDD.Location = new System.Drawing.Point(12, 137);
            this.RadioBoxHDD.Name = "RadioBoxHDD";
            this.RadioBoxHDD.Size = new System.Drawing.Size(146, 22);
            this.RadioBoxHDD.TabIndex = 17;
            this.RadioBoxHDD.Text = "Spoof Volume IDs";
            this.RadioBoxHDD.UseVisualStyleBackColor = true;
            // 
            // RadioBoxMAC
            // 
            this.RadioBoxMAC.AutoSize = true;
            this.RadioBoxMAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxMAC.Location = new System.Drawing.Point(12, 107);
            this.RadioBoxMAC.Name = "RadioBoxMAC";
            this.RadioBoxMAC.Size = new System.Drawing.Size(177, 22);
            this.RadioBoxMAC.TabIndex = 16;
            this.RadioBoxMAC.Text = "Spoof MAC Addresses";
            this.RadioBoxMAC.UseVisualStyleBackColor = true;
            // 
            // RadioBoxBIOS
            // 
            this.RadioBoxBIOS.AutoSize = true;
            this.RadioBoxBIOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxBIOS.Location = new System.Drawing.Point(12, 76);
            this.RadioBoxBIOS.Name = "RadioBoxBIOS";
            this.RadioBoxBIOS.Size = new System.Drawing.Size(183, 22);
            this.RadioBoxBIOS.TabIndex = 15;
            this.RadioBoxBIOS.Text = "BIOS Spoof (AMI BIOS)";
            this.RadioBoxBIOS.UseVisualStyleBackColor = true;
            // 
            // RadioBoxHKeys
            // 
            this.RadioBoxHKeys.AutoSize = true;
            this.RadioBoxHKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxHKeys.Location = new System.Drawing.Point(12, 46);
            this.RadioBoxHKeys.Name = "RadioBoxHKeys";
            this.RadioBoxHKeys.Size = new System.Drawing.Size(112, 22);
            this.RadioBoxHKeys.TabIndex = 14;
            this.RadioBoxHKeys.Text = "Clean HKeys";
            this.RadioBoxHKeys.UseVisualStyleBackColor = true;
            // 
            // RadioBoxTracers
            // 
            this.RadioBoxTracers.AutoSize = true;
            this.RadioBoxTracers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioBoxTracers.Location = new System.Drawing.Point(12, 16);
            this.RadioBoxTracers.Name = "RadioBoxTracers";
            this.RadioBoxTracers.Size = new System.Drawing.Size(119, 22);
            this.RadioBoxTracers.TabIndex = 13;
            this.RadioBoxTracers.Text = "Clean Tracers";
            this.RadioBoxTracers.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.BackColor = System.Drawing.Color.Lime;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Tai Le", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnExecute.Location = new System.Drawing.Point(10, 594);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(195, 81);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "EXECUTE";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // fakeConsole
            // 
            this.fakeConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fakeConsole.BackColor = System.Drawing.Color.Black;
            this.fakeConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fakeConsole.CausesValidation = false;
            this.fakeConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.fakeConsole.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fakeConsole.ForeColor = System.Drawing.Color.Lime;
            this.fakeConsole.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.fakeConsole.Location = new System.Drawing.Point(236, 25);
            this.fakeConsole.Name = "fakeConsole";
            this.fakeConsole.ReadOnly = true;
            this.fakeConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.fakeConsole.ShortcutsEnabled = false;
            this.fakeConsole.Size = new System.Drawing.Size(544, 645);
            this.fakeConsole.TabIndex = 4;
            this.fakeConsole.TabStop = false;
            this.fakeConsole.Text = "";
            // 
            // logo
            // 
            this.logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo.InitialImage")));
            this.logo.Location = new System.Drawing.Point(14, 20);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(197, 132);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 5;
            this.logo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(230, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(558, 655);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // AppForm
            // 
            this.AcceptButton = this.btnExecute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 697);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.fakeConsole);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 535);
            this.Name = "AppForm";
            this.Text = "Modest Gieik Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RadioButton RadioBoxCleanAll;
        private System.Windows.Forms.RadioButton RadioBoxHDD;
        private System.Windows.Forms.RadioButton RadioBoxMAC;
        private System.Windows.Forms.RadioButton RadioBoxBIOS;
        private System.Windows.Forms.RadioButton RadioBoxHKeys;
        private System.Windows.Forms.RadioButton RadioBoxTracers;
        public System.Windows.Forms.RichTextBox fakeConsole;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

