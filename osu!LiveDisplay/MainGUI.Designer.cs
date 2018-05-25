using System.Windows.Forms;

namespace osu_LiveDisplay
{
    partial class MainGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.locateOsu = new System.Windows.Forms.Button();
            this.osuLocation = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.dbEntries = new System.Windows.Forms.ListBox();
            this.hiddenOnMenu = new System.Windows.Forms.CheckBox();
            this.scrollSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.waitTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "osu.db";
            // 
            // locateOsu
            // 
            this.locateOsu.ForeColor = System.Drawing.Color.Black;
            this.locateOsu.Location = new System.Drawing.Point(12, 269);
            this.locateOsu.Name = "locateOsu";
            this.locateOsu.Size = new System.Drawing.Size(75, 23);
            this.locateOsu.TabIndex = 3;
            this.locateOsu.Text = "Locate osu!";
            this.locateOsu.UseVisualStyleBackColor = true;
            this.locateOsu.Click += new System.EventHandler(this.locateOsu_Click);
            // 
            // osuLocation
            // 
            this.osuLocation.AutoSize = true;
            this.osuLocation.ForeColor = System.Drawing.Color.Black;
            this.osuLocation.Location = new System.Drawing.Point(93, 274);
            this.osuLocation.Name = "osuLocation";
            this.osuLocation.Size = new System.Drawing.Size(16, 13);
            this.osuLocation.TabIndex = 4;
            this.osuLocation.Text = "...";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            // 
            // dbEntries
            // 
            this.dbEntries.FormattingEnabled = true;
            this.dbEntries.Location = new System.Drawing.Point(12, 25);
            this.dbEntries.Name = "dbEntries";
            this.dbEntries.Size = new System.Drawing.Size(452, 238);
            this.dbEntries.TabIndex = 5;
            this.dbEntries.SelectedIndexChanged += new System.EventHandler(this.dbEntries_SelectedIndexChanged);
            // 
            // hiddenOnMenu
            // 
            this.hiddenOnMenu.AutoSize = true;
            this.hiddenOnMenu.ForeColor = System.Drawing.Color.Black;
            this.hiddenOnMenu.Location = new System.Drawing.Point(12, 308);
            this.hiddenOnMenu.Name = "hiddenOnMenu";
            this.hiddenOnMenu.Size = new System.Drawing.Size(106, 17);
            this.hiddenOnMenu.TabIndex = 6;
            this.hiddenOnMenu.Text = "Hidden in menu?";
            this.hiddenOnMenu.UseVisualStyleBackColor = true;
            // 
            // scrollSpeed
            // 
            this.scrollSpeed.Location = new System.Drawing.Point(12, 331);
            this.scrollSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scrollSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrollSpeed.Name = "scrollSpeed";
            this.scrollSpeed.Size = new System.Drawing.Size(39, 20);
            this.scrollSpeed.TabIndex = 7;
            this.scrollSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Scrollspeed";
            // 
            // waitTime
            // 
            this.waitTime.Location = new System.Drawing.Point(129, 308);
            this.waitTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.waitTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waitTime.Name = "waitTime";
            this.waitTime.Size = new System.Drawing.Size(39, 20);
            this.waitTime.TabIndex = 9;
            this.waitTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wait (in s)";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waitTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scrollSpeed);
            this.Controls.Add(this.hiddenOnMenu);
            this.Controls.Add(this.dbEntries);
            this.Controls.Add(this.osuLocation);
            this.Controls.Add(this.locateOsu);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGUI";
            this.Text = "osu!LiveDisplay Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button locateOsu;
        private Label osuLocation;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private ListBox dbEntries;
        public CheckBox hiddenOnMenu;
        private Label label2;
        public NumericUpDown scrollSpeed;
        private Label label3;
        public NumericUpDown waitTime;
    }
}