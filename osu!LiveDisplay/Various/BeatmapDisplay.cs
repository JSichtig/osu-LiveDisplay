using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using osu.Shared;
using osu_database_reader.Components.Beatmaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu_LiveDisplay.Various
{
    public class BeatmapDisplay
    {
        GraphicsDevice gd;
        SpriteBatch spriteBatch;
        ContentManager content;

        private BeatmapEntry bmEntry;
        public BeatmapEntry BeatmapEntry
        {
            get { return bmEntry; }
        }

        Texture2D myBackground;

        ScrollableText titleText;
        ScrollableText artistText;

        Effect curvedBorder;
        Effect textCutOff;

        public BeatmapDisplay(GraphicsDevice gd, ContentManager content, BeatmapEntry bmEntry)
        {
            this.bmEntry = bmEntry;
            this.gd = gd;
            spriteBatch = new SpriteBatch(gd);
            this.content = content;

            curvedBorder = content.Load<Effect>("border-radius");
            curvedBorder.Parameters["MaskTexture"].SetValue(content.Load<Texture2D>("MaskTexture"));
            textCutOff = content.Load<Effect>("TextCutoff");

            this.Init();
        }

        private void Init()
        {
            // Get CardTexture if the map is submitted / ranked, if not replace with default
            if (bmEntry.RankedStatus != SubmissionStatus.NotSubmitted && bmEntry.RankedStatus != SubmissionStatus.Unknown)
            {
                var req = WebRequest.Create("https://assets.ppy.sh/beatmaps/" + bmEntry.BeatmapSetId + "/covers/card@2x.jpg");
                Texture2D cardTexture;
                using (Stream stream = req.GetResponse().GetResponseStream())
                {
                    cardTexture = Texture2D.FromStream(gd, stream);
                }
                if (cardTexture != null)
                {
                    myBackground = cardTexture;
                }
            }
            else
            {
                myBackground = content.Load<Texture2D>("EmptyCard");
            }

            titleText = new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalic"), bmEntry.Title + ((bmEntry.Version == "") ? "" : " [" + bmEntry.Version + "]"), new Vector2(40, 20));
            artistText = new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalicSmall"), bmEntry.Artist + " // " + bmEntry.Creator, new Vector2(40, 66));
        }

        public void Update(GameTime gameTime)
        {
            titleText.Update(gameTime);
            artistText.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            // background
            spriteBatch.Begin(effect: curvedBorder, blendState: BlendState.AlphaBlend);
                Rectangle sourceRect = new Rectangle(0, 0, myBackground.Width, myBackground.Height);
                Rectangle destinationRect = new Rectangle(0, 0, 940, 150);
                spriteBatch.Draw(myBackground, destinationRect, sourceRect, Color.White);
            spriteBatch.End();

            // text
            spriteBatch.Begin(effect: textCutOff);
                titleText.Draw(gameTime, spriteBatch);
            if (bmEntry.Artist != "" && bmEntry.Creator != "")
                artistText.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }

    public class ScrollableText
    {
        GraphicsDevice graphicsDevice;

        SpriteFont font;
        string text;
        Vector2 position;
        Vector2 size;
        int resetCounter = 0;

        public ScrollableText(GraphicsDevice graphicsDevice, SpriteFont font, string text, Vector2 position)
        {
            this.graphicsDevice = graphicsDevice;

            this.font = font;
            this.text = text;

            // measure size and set inital position
            this.position = position;
            this.size = font.MeasureString(this.text);
        }

        public void Update(GameTime gameTime)
        {
            if (size.X > 860)
            {
                if (position.X + size.X > 860)
                {
                    if (position.X == 40)
                    {
                        resetCounter += gameTime.ElapsedGameTime.Milliseconds;
                        if (resetCounter > 1000 * (int)Config.GetEntry("waitingTime"))
                        {
                            position.X -= ((int)Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                            resetCounter = 0;
                        }
                    }
                    else
                    {
                        position.X -= ((int)Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                    }
                }
                else
                {
                    position.X = 860 - size.X;
                    resetCounter += gameTime.ElapsedGameTime.Milliseconds;
                    if (resetCounter > 1000 * (int)Config.GetEntry("waitingTime"))
                    {
                        position.X = 40;
                        resetCounter = 0;
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
