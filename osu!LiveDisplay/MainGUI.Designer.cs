﻿using System.Windows.Forms;

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
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lockDisplay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.switchDisplayed = new System.Windows.Forms.NumericUpDown();
            this.isBorderless = new System.Windows.Forms.CheckBox();
            this.snapToGUI = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switchDisplayed)).BeginInit();
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
            this.locateOsu.Location = new System.Drawing.Point(11, 24);
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
            this.osuLocation.Location = new System.Drawing.Point(92, 29);
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
            this.hiddenOnMenu.Location = new System.Drawing.Point(11, 68);
            this.hiddenOnMenu.Name = "hiddenOnMenu";
            this.hiddenOnMenu.Size = new System.Drawing.Size(100, 17);
            this.hiddenOnMenu.TabIndex = 6;
            this.hiddenOnMenu.Text = "Hidden in menu";
            this.hiddenOnMenu.UseVisualStyleBackColor = true;
            this.hiddenOnMenu.CheckedChanged += new System.EventHandler(this.hiddenOnMenu_CheckedChanged);
            // 
            // scrollSpeed
            // 
            this.scrollSpeed.Location = new System.Drawing.Point(11, 96);
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
            this.scrollSpeed.ValueChanged += new System.EventHandler(this.scrollSpeed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Scrollspeed";
            // 
            // waitTime
            // 
            this.waitTime.Location = new System.Drawing.Point(11, 127);
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
            this.waitTime.ValueChanged += new System.EventHandler(this.waitTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Scrolldelay";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(366, 24);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockDisplay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.switchDisplayed);
            this.groupBox1.Controls.Add(this.isBorderless);
            this.groupBox1.Controls.Add(this.snapToGUI);
            this.groupBox1.Controls.Add(this.hiddenOnMenu);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.scrollSpeed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.osuLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.locateOsu);
            this.groupBox1.Controls.Add(this.waitTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 166);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings (red = requires restart)";
            // 
            // hideStats
            // 
            this.lockDisplay.AutoSize = true;
            this.lockDisplay.Location = new System.Drawing.Point(258, 68);
            this.lockDisplay.Name = "hideStats";
            this.lockDisplay.Size = new System.Drawing.Size(50, 17);
            this.lockDisplay.TabIndex = 16;
            this.lockDisplay.Text = "Lock";
            this.lockDisplay.UseVisualStyleBackColor = true;
            this.lockDisplay.CheckedChanged += new System.EventHandler(this.hideStats_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Switch";
            // 
            // switchDisplayed
            // 
            this.switchDisplayed.Location = new System.Drawing.Point(258, 96);
            this.switchDisplayed.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.switchDisplayed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.switchDisplayed.Name = "switchDisplayed";
            this.switchDisplayed.Size = new System.Drawing.Size(39, 20);
            this.switchDisplayed.TabIndex = 14;
            this.switchDisplayed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.switchDisplayed.ValueChanged += new System.EventHandler(this.switchDisplayed_ValueChanged);
            // 
            // isBorderless
            // 
            this.isBorderless.AutoSize = true;
            this.isBorderless.ForeColor = System.Drawing.Color.Brown;
            this.isBorderless.Location = new System.Drawing.Point(147, 99);
            this.isBorderless.Name = "isBorderless";
            this.isBorderless.Size = new System.Drawing.Size(75, 17);
            this.isBorderless.TabIndex = 13;
            this.isBorderless.Text = "Borderless";
            this.isBorderless.UseVisualStyleBackColor = true;
            this.isBorderless.CheckedChanged += new System.EventHandler(this.isBorderless_CheckedChanged);
            // 
            // snapToGUI
            // 
            this.snapToGUI.AutoSize = true;
            this.snapToGUI.Location = new System.Drawing.Point(147, 68);
            this.snapToGUI.Name = "snapToGUI";
            this.snapToGUI.Size = new System.Drawing.Size(85, 17);
            this.snapToGUI.TabIndex = 12;
            this.snapToGUI.Text = "Snap to GUI";
            this.snapToGUI.UseVisualStyleBackColor = true;
            this.snapToGUI.CheckedChanged += new System.EventHandler(this.snapToGUI_CheckedChanged);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dbEntries);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGUI";
            this.Text = "osu!LiveDisplay Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_Closing);
            this.Load += new System.EventHandler(this.MainGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switchDisplayed)).EndInit();
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
        private Button saveButton;
        private GroupBox groupBox1;
        private CheckBox snapToGUI;
        private CheckBox isBorderless;
        private Label label4;
        public NumericUpDown switchDisplayed;
        private CheckBox lockDisplay;
    }
}