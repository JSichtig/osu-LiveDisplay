using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using osu.Shared;
using osu_database_reader.BinaryFiles;
using osu_database_reader.Components.Beatmaps;
using osu_LiveDisplay.Various;
using System;
using System.IO;
using System.Net;

namespace osu_LiveDisplay
{
    public class MonoDisplay : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public BeatmapDisplay currentBeatmap;

        private NameChangeTracker nameChangeTracker;

        private OsuDb osuDatabase;
        public OsuDb OsuDataBase
        {
            get { return this.osuDatabase; }
        }

        private Action osuDataBaseLoadedCallback = null;
        public Action OsuDataBaseLoadedCallback
        {
            set { this.osuDataBaseLoadedCallback = value; }
            get { return this.osuDataBaseLoadedCallback; }
        }

        public MonoDisplay()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 940;
            graphics.PreferredBackBufferHeight = 150;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            Config.ReadConfig();

            if((bool) Config.GetEntry("isBorderless"))
                this.Window.IsBorderless = true;
            this.IsMouseVisible = true;
            this.Window.Title = "osu!LiveDisplay Output";

            nameChangeTracker = new NameChangeTracker(this.OsuTitleChanged);

            if ((string)Config.GetEntry("osuLocation") != "")
                LoadOsuDatabase();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if((bool)Config.GetEntry("snapToGUI"))
                if(MainGUI.mainGUI != null)
                    this.Window.Position = new Point(MainGUI.mainGUI.Location.X + MainGUI.mainGUI.Size.Width + 10, MainGUI.mainGUI.Location.Y + 30);

            if (currentBeatmap != null)
                currentBeatmap.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(255, 0, 255));

            if (currentBeatmap != null)
            {
                if (currentBeatmap.BeatmapEntry.Title == "Waiting for beatmap..." && (bool) Config.GetEntry("hiddenOnMenu"))
                {
                    base.Draw(gameTime);
                    return;
                }
                currentBeatmap.Draw(gameTime);
            }

            base.Draw(gameTime);
        }

        public void BuildLiveDisplay(BeatmapEntry beatmap)
        {
            currentBeatmap = new BeatmapDisplay(GraphicsDevice, Content, beatmap);
        }

        public void LoadOsuDatabase()
        {
            osuDatabase = OsuDb.Read(Config.GetEntry("osuLocation") + "/osu!.db");
            if (osuDataBaseLoadedCallback != null)
                osuDataBaseLoadedCallback();
        }

        public void OsuTitleChanged(String title)
        {
            // sample osu!cuttingedge b20180510 - Wada Kouji - FIRE!! ~TV Size~ [GET A FIRE POWER!!]
            String res = title;
            if (res.IndexOf(" - ") > 0)
            {
                res = res.Remove(0, res.IndexOf(" - ") + 3);
                foreach (BeatmapEntry bm in osuDatabase.Beatmaps)
                {
                    if ($"{bm.Artist} - {bm.Title} [{bm.Version}]" == res)
                    {
                        BuildLiveDisplay(bm);
                        return;
                    }
                }

                // if no title is found in database, parse "Unknown beatmap"
                BeatmapEntry unknown = new BeatmapEntry();
                unknown.Title = "Unknown Title";
                unknown.Artist = "";
                unknown.Version = "";
                BuildLiveDisplay(unknown);
            }
            else if (currentBeatmap != null)
            {
                BeatmapEntry unknown = new BeatmapEntry();
                unknown.Title = "Waiting for beatmap...";
                unknown.Artist = "";
                unknown.Version = "";
                BuildLiveDisplay(unknown);
            }
        }

        protected override void OnExiting(Object sender, EventArgs args)
        {
            NameChangeTracker.UnhookWinEvent(nameChangeTracker.hhook);
            base.OnExiting(sender, args);
        }
    }
}
