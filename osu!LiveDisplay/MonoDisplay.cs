using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using osu.Shared;
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

        public static MainGUI myGUI;
        public BeatmapDisplay currentBeatmap;

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
            this.Window.IsBorderless = true;
            this.IsMouseVisible = true;
            this.Window.Title = "osu!LiveDisplay Output";
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
            this.Window.Position = new Point(myGUI.Location.X + myGUI.Width, myGUI.Location.Y);
            if (currentBeatmap != null)
            {
                currentBeatmap.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(255, 0, 255));

            if (currentBeatmap != null)
            {
                if (currentBeatmap.BeatmapEntry.Title == "Waiting for beatmap..." && myGUI.hiddenOnMenu.Checked)
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

        protected override void OnExiting(Object sender, EventArgs args)
        {
            NameChangeTracker.UnhookWinEvent(MainGUI.me.nameChangeTracker.hhook);
            base.OnExiting(sender, args);
        }
    }
}
