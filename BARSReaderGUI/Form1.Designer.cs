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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            AssetListBox = new ListBox();
            groupBox2 = new GroupBox();
            extractAllButton = new Button();
            AudioAssetIsPrefetchLabel = new Label();
            label5 = new Label();
            extractMetaButton = new Button();
            extractAudioButton = new Button();
            AudioAssetBwavOffsetLabel = new Label();
            label4 = new Label();
            AudioAssetAmtaOffsetLabel = new Label();
            label3 = new Label();
            AudioAssetCrc32HashLabel = new Label();
            label2 = new Label();
            AudioAssetNameLabel = new Label();
            label1 = new Label();
            batchExtractToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(605, 26);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, batchExtractToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AssetListBox);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 26);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(354, 402);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Assets";
            // 
            // AssetListBox
            // 
            AssetListBox.Dock = DockStyle.Fill;
            AssetListBox.FormattingEnabled = true;
            AssetListBox.ItemHeight = 20;
            AssetListBox.Location = new Point(2, 21);
            AssetListBox.Margin = new Padding(2, 1, 2, 1);
            AssetListBox.Name = "AssetListBox";
            AssetListBox.Size = new Size(350, 380);
            AssetListBox.TabIndex = 0;
            AssetListBox.SelectedIndexChanged += AssetListBox_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(extractAllButton);
            groupBox2.Controls.Add(AudioAssetIsPrefetchLabel);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(extractMetaButton);
            groupBox2.Controls.Add(extractAudioButton);
            groupBox2.Controls.Add(AudioAssetBwavOffsetLabel);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(AudioAssetAmtaOffsetLabel);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(AudioAssetCrc32HashLabel);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(AudioAssetNameLabel);
            groupBox2.Controls.Add(label1);
            groupBox2.Dock = DockStyle.Right;
            groupBox2.Location = new Point(359, 26);
            groupBox2.Margin = new Padding(2, 1, 2, 1);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 1, 2, 1);
            groupBox2.Size = new Size(246, 402);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Asset Info";
            // 
            // extractAllButton
            // 
            extractAllButton.Enabled = false;
            extractAllButton.Location = new Point(5, 352);
            extractAllButton.Margin = new Padding(2, 1, 2, 1);
            extractAllButton.Name = "extractAllButton";
            extractAllButton.Size = new Size(237, 29);
            extractAllButton.TabIndex = 12;
            extractAllButton.Text = "Extract All Audio";
            extractAllButton.UseVisualStyleBackColor = true;
            extractAllButton.Click += extractAllButton_Click;
            // 
            // AudioAssetIsPrefetchLabel
            // 
            AudioAssetIsPrefetchLabel.AutoSize = true;
            AudioAssetIsPrefetchLabel.Location = new Point(3, 201);
            AudioAssetIsPrefetchLabel.Name = "AudioAssetIsPrefetchLabel";
            AudioAssetIsPrefetchLabel.Size = new Size(74, 20);
            AudioAssetIsPrefetchLabel.TabIndex = 11;
            AudioAssetIsPrefetchLabel.Text = "isprefetch";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 181);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 10;
            label5.Text = "IsPrefetch";
            // 
            // extractMetaButton
            // 
            extractMetaButton.Enabled = false;
            extractMetaButton.Location = new Point(5, 288);
            extractMetaButton.Margin = new Padding(2, 1, 2, 1);
            extractMetaButton.Name = "extractMetaButton";
            extractMetaButton.Size = new Size(237, 29);
            extractMetaButton.TabIndex = 9;
            extractMetaButton.Text = "Extract Meta";
            extractMetaButton.UseVisualStyleBackColor = true;
            extractMetaButton.Click += extractMetaButton_Click;
            // 
            // extractAudioButton
            // 
            extractAudioButton.Enabled = false;
            extractAudioButton.Location = new Point(5, 320);
            extractAudioButton.Margin = new Padding(2, 1, 2, 1);
            extractAudioButton.Name = "extractAudioButton";
            extractAudioButton.Size = new Size(237, 29);
            extractAudioButton.TabIndex = 8;
            extractAudioButton.Text = "Extract Audio";
            extractAudioButton.UseVisualStyleBackColor = true;
            extractAudioButton.Click += extractAudioButton_Click;
            // 
            // AudioAssetBwavOffsetLabel
            // 
            AudioAssetBwavOffsetLabel.AutoSize = true;
            AudioAssetBwavOffsetLabel.Location = new Point(3, 161);
            AudioAssetBwavOffsetLabel.Margin = new Padding(2, 0, 2, 0);
            AudioAssetBwavOffsetLabel.Name = "AudioAssetBwavOffsetLabel";
            AudioAssetBwavOffsetLabel.Size = new Size(82, 20);
            AudioAssetBwavOffsetLabel.TabIndex = 7;
            AudioAssetBwavOffsetLabel.Text = "assetOffset";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 141);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 6;
            label4.Text = "Asset Offset";
            // 
            // AudioAssetAmtaOffsetLabel
            // 
            AudioAssetAmtaOffsetLabel.AutoSize = true;
            AudioAssetAmtaOffsetLabel.Location = new Point(3, 121);
            AudioAssetAmtaOffsetLabel.Margin = new Padding(2, 0, 2, 0);
            AudioAssetAmtaOffsetLabel.Name = "AudioAssetAmtaOffsetLabel";
            AudioAssetAmtaOffsetLabel.Size = new Size(83, 20);
            AudioAssetAmtaOffsetLabel.TabIndex = 5;
            AudioAssetAmtaOffsetLabel.Text = "amtaOffset";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 101);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 4;
            label3.Text = "Meta Offset";
            // 
            // AudioAssetCrc32HashLabel
            // 
            AudioAssetCrc32HashLabel.AutoSize = true;
            AudioAssetCrc32HashLabel.Location = new Point(3, 81);
            AudioAssetCrc32HashLabel.Margin = new Padding(2, 0, 2, 0);
            AudioAssetCrc32HashLabel.Name = "AudioAssetCrc32HashLabel";
            AudioAssetCrc32HashLabel.Size = new Size(61, 20);
            AudioAssetCrc32HashLabel.TabIndex = 3;
            AudioAssetCrc32HashLabel.Text = "crcHash";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 61);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 2;
            label2.Text = "Name Hash";
            // 
            // AudioAssetNameLabel
            // 
            AudioAssetNameLabel.AutoSize = true;
            AudioAssetNameLabel.Location = new Point(3, 41);
            AudioAssetNameLabel.Margin = new Padding(2, 0, 2, 0);
            AudioAssetNameLabel.Name = "AudioAssetNameLabel";
            AudioAssetNameLabel.Size = new Size(79, 20);
            AudioAssetNameLabel.TabIndex = 1;
            AudioAssetNameLabel.Text = "assetname";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 21);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // batchExtractToolStripMenuItem
            // 
            batchExtractToolStripMenuItem.Name = "batchExtractToolStripMenuItem";
            batchExtractToolStripMenuItem.Size = new Size(224, 26);
            batchExtractToolStripMenuItem.Text = "Batch Extract...";
            batchExtractToolStripMenuItem.Click += BatchExtract_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(605, 428);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "BARSReaderGUI";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private GroupBox groupBox1;
        private ListBox AssetListBox;
        private GroupBox groupBox2;
        private Label label2;
        private Label AudioAssetNameLabel;
        private Label label1;
        private Label AudioAssetCrc32HashLabel;
        private Label AudioAssetBwavOffsetLabel;
        private Label label4;
        private Label AudioAssetAmtaOffsetLabel;
        private Label label3;
        private Button extractAudioButton;
        private Button extractMetaButton;
        private Label AudioAssetIsPrefetchLabel;
        private Label label5;
        private Button extractAllButton;
        private ToolStripMenuItem batchExtractToolStripMenuItem;
    }
}