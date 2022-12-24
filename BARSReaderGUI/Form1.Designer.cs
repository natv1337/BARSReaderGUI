namespace BARSReaderGUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BwavListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AudioAssetBwavOffsetLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AudioAssetAmtaOffsetLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AudioAssetCrc32HashLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AudioAssetNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(431, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BwavListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(215, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assets";
            // 
            // BwavListBox
            // 
            this.BwavListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BwavListBox.FormattingEnabled = true;
            this.BwavListBox.ItemHeight = 15;
            this.BwavListBox.Location = new System.Drawing.Point(2, 17);
            this.BwavListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BwavListBox.Name = "BwavListBox";
            this.BwavListBox.Size = new System.Drawing.Size(211, 169);
            this.BwavListBox.TabIndex = 0;
            this.BwavListBox.SelectedIndexChanged += new System.EventHandler(this.BwavListBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AudioAssetBwavOffsetLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.AudioAssetAmtaOffsetLabel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.AudioAssetCrc32HashLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.AudioAssetNameLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(216, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox2.Size = new System.Drawing.Size(215, 187);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asset Info";
            // 
            // AudioAssetBwavOffsetLabel
            // 
            this.AudioAssetBwavOffsetLabel.AutoSize = true;
            this.AudioAssetBwavOffsetLabel.Location = new System.Drawing.Point(3, 121);
            this.AudioAssetBwavOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AudioAssetBwavOffsetLabel.Name = "AudioAssetBwavOffsetLabel";
            this.AudioAssetBwavOffsetLabel.Size = new System.Drawing.Size(65, 15);
            this.AudioAssetBwavOffsetLabel.TabIndex = 7;
            this.AudioAssetBwavOffsetLabel.Text = "assetOffset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Asset Offset";
            // 
            // AudioAssetAmtaOffsetLabel
            // 
            this.AudioAssetAmtaOffsetLabel.AutoSize = true;
            this.AudioAssetAmtaOffsetLabel.Location = new System.Drawing.Point(3, 91);
            this.AudioAssetAmtaOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AudioAssetAmtaOffsetLabel.Name = "AudioAssetAmtaOffsetLabel";
            this.AudioAssetAmtaOffsetLabel.Size = new System.Drawing.Size(66, 15);
            this.AudioAssetAmtaOffsetLabel.TabIndex = 5;
            this.AudioAssetAmtaOffsetLabel.Text = "amtaOffset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Meta Offset";
            // 
            // AudioAssetCrc32HashLabel
            // 
            this.AudioAssetCrc32HashLabel.AutoSize = true;
            this.AudioAssetCrc32HashLabel.Location = new System.Drawing.Point(3, 61);
            this.AudioAssetCrc32HashLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AudioAssetCrc32HashLabel.Name = "AudioAssetCrc32HashLabel";
            this.AudioAssetCrc32HashLabel.Size = new System.Drawing.Size(50, 15);
            this.AudioAssetCrc32HashLabel.TabIndex = 3;
            this.AudioAssetCrc32HashLabel.Text = "crcHash";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name Hash";
            // 
            // AudioAssetNameLabel
            // 
            this.AudioAssetNameLabel.AutoSize = true;
            this.AudioAssetNameLabel.Location = new System.Drawing.Point(3, 31);
            this.AudioAssetNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AudioAssetNameLabel.Name = "AudioAssetNameLabel";
            this.AudioAssetNameLabel.Size = new System.Drawing.Size(63, 15);
            this.AudioAssetNameLabel.TabIndex = 1;
            this.AudioAssetNameLabel.Text = "assetname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(431, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "BARSReaderGUI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private GroupBox groupBox1;
        private ListBox BwavListBox;
        private GroupBox groupBox2;
        private Label label2;
        private Label AudioAssetNameLabel;
        private Label label1;
        private Label AudioAssetCrc32HashLabel;
        private Label AudioAssetBwavOffsetLabel;
        private Label label4;
        private Label AudioAssetAmtaOffsetLabel;
        private Label label3;
    }
}