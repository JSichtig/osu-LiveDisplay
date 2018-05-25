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

namespace osu_LiveDisplay
{
    public partial class MainGUI : Form
    {
        public static MainGUI me;
        public MonoDisplay myGame;
        public String osuPath;
        public OsuDb osuDB;

        public NameChangeTracker nameChangeTracker;

        public MainGUI()
        {
            InitializeComponent();
            me = this;

            nameChangeTracker = new NameChangeTracker();
        }

        public void OsuTitleChanged(String title)
        {
            // sample osu!cuttingedge b20180510 - Wada Kouji - FIRE!! ~TV Size~ [GET A FIRE POWER!!]
            String res = title;
            if(res.IndexOf(" - ") > 0)
            {
                res = res.Remove(0, res.IndexOf(" - ") + 3);
                foreach (BeatmapEntry bm in osuDB.Beatmaps)
                {
                    if ($"{bm.Artist} - {bm.Title} [{bm.Version}]" == res)
                    {
                        myGame.BuildLiveDisplay(bm);
                        return;
                    }
                }

                // if no title is found in database, parse "Unknown beatmap"
                BeatmapEntry unknown = new BeatmapEntry();
                unknown.Title = "Unknown Title";
                unknown.Artist = "";
                unknown.Version = "";
                myGame.BuildLiveDisplay(unknown);
            } 
            else if(myGame.currentBeatmap != null)
            {
                BeatmapEntry unknown = new BeatmapEntry();
                unknown.Title = "Waiting for beatmap...";
                unknown.Artist = "";
                unknown.Version = "";
                myGame.BuildLiveDisplay(unknown);
            }
        }

        private void MainGUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NameChangeTracker.UnhookWinEvent(nameChangeTracker.hhook);
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
                LoadDatabase();
            }
        }

        private void LoadDatabase()
        {
            osuDB = OsuDb.Read(osuPath + "/osu!.db");
            dbEntries.Items.Clear();
            foreach(BeatmapEntry beatmap in osuDB.Beatmaps)
            {
                dbEntries.Items.Add(beatmap.Artist + " - " + beatmap.Title + " [" + beatmap.Version + "]");
            }
        }

        private void dbEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            myGame.BuildLiveDisplay(osuDB.Beatmaps[dbEntries.SelectedIndex]);
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            LoadDatabase();
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            LoadDatabase();
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            LoadDatabase();
        }
    }
}
