using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using osu_database_reader.BinaryFiles;
using osu_database_reader.Components.Beatmaps;
using osu_database_reader.TextFiles;
using osu_LiveDisplay.Various;

namespace osu_LiveDisplay
{
    public partial class MainGUI : Form
    {
        public static MainGUI mainGUI;

        public MonoDisplay myGame;
        public String osuPath;

        public MainGUI()
        {
            InitializeComponent();
            mainGUI = this;
        }

        public void Initialize()
        {
            myGame.OsuDataBaseLoadedCallback = this.OnDataBaseLoaded;
        }

        public void OnDataBaseLoaded()
        {
            foreach (BeatmapEntry bmEntry in myGame.OsuDataBase.Beatmaps)
            {
                dbEntries.Items.Add($"{bmEntry.Artist} - {bmEntry.Title} [{bmEntry.Version}]");
            }
        }

        private void MainGUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myGame.Exit();
        }

        private void locateOsu_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                osuPath = folderBrowserDialog1.SelectedPath;
                osuLocation.Text = osuPath;
                // load osu.db
                Config.SetEntry("osuLocation", osuPath);
                myGame.LoadOsuDatabase();
            }
        }

        private void dbEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            myGame.BuildLiveDisplay(myGame.OsuDataBase.Beatmaps[dbEntries.SelectedIndex]);
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            myGame.LoadOsuDatabase();
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            myGame.LoadOsuDatabase();
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            myGame.LoadOsuDatabase();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            
        }

        public void OnConfigRead()
        {
            hiddenOnMenu.Checked = (bool) Config.GetEntry("hiddenOnMenu");
            snapToGUI.Checked = (bool)Config.GetEntry("snapToGUI");
            isBorderless.Checked = (bool)Config.GetEntry("isBorderless");

            scrollSpeed.Value = (int) Config.GetEntry("scrollSpeed");
            waitTime.Value = (int) Config.GetEntry("waitingTime");

            osuLocation.Text = (string)Config.GetEntry("osuLocation") == "" ? "..." : (string)Config.GetEntry("osuLocation");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Config.SaveSettings();
        }

        private void hiddenOnMenu_CheckedChanged(object sender, EventArgs e)
        {
            Config.SetEntry("hiddenOnMenu", (bool) hiddenOnMenu.Checked);
        }

        private void waitTime_ValueChanged(object sender, EventArgs e)
        {
            Config.SetEntry("waitingTime", (int) waitTime.Value);
        }

        private void scrollSpeed_ValueChanged(object sender, EventArgs e)
        {
            Config.SetEntry("scrollSpeed",(int) scrollSpeed.Value);
        }

        private void snapToGUI_CheckedChanged(object sender, EventArgs e)
        {
            Config.SetEntry("snapToGUI", (bool) snapToGUI.Checked);
        }

        private void isBorderless_CheckedChanged(object sender, EventArgs e)
        {
            Config.SetEntry("isBorderless", (bool) isBorderless.Checked);
        }
    }
}
