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
        string titleOutput;
        string artistOutput;

        Vector2 titlePosition;
        Vector2 artistPosition;
        Vector2 titleSize;
        Vector2 artistSize;
        int titleResetCounter = 0;
        int artistResetCounter = 0;

        Effect curvedBorder;
        Effect textCutOff;

        SpriteFont exo2SemiBoldItalic;
        SpriteFont exo2SemiBoldItalicSmall;

        public BeatmapDisplay(GraphicsDevice gd, ContentManager content, BeatmapEntry bmEntry)
        {
            this.bmEntry = bmEntry;
            this.gd = gd;
            spriteBatch = new SpriteBatch(gd);
            this.content = content;

            exo2SemiBoldItalic = content.Load<SpriteFont>("Exo2SemiBoldItalic");
            exo2SemiBoldItalicSmall = content.Load<SpriteFont>("Exo2SemiBoldItalicSmall");

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

            titleOutput = bmEntry.Title + ((bmEntry.Version == "") ? "" : " [" + bmEntry.Version + "]");
            artistOutput = bmEntry.Artist + " // " + bmEntry.Creator;

            titlePosition = new Vector2(40, 20);
            artistPosition = new Vector2(40, 66);

            titleSize = exo2SemiBoldItalic.MeasureString(titleOutput);
            artistSize = exo2SemiBoldItalicSmall.MeasureString(artistOutput);

            titleResetCounter = 0;
            artistResetCounter = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (titleSize.X > 860)
            {
                if (titlePosition.X + titleSize.X > 860)
                {
                    if (titlePosition.X == 40)
                    {
                        titleResetCounter += gameTime.ElapsedGameTime.Milliseconds;
                        if (titleResetCounter > 1000 * (int) Config.GetEntry("waitingTime"))
                        {
                            titlePosition.X -= ((int) Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                            titleResetCounter = 0;
                        }
                    }
                    else
                    {
                        titlePosition.X -= ((int) Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                    }
                }
                else
                {
                    titlePosition.X = 860 - titleSize.X;
                    titleResetCounter += gameTime.ElapsedGameTime.Milliseconds;
                    if (titleResetCounter > 1000 * (int) Config.GetEntry("waitingTime"))
                    {
                        titlePosition.X = 40;
                        titleResetCounter = 0;
                    }
                }
            }

            if (artistSize.X > 860)
            {
                if (artistPosition.X + artistSize.X > 860)
                {
                    if (artistPosition.X == 40)
                    {
                        artistResetCounter += gameTime.ElapsedGameTime.Milliseconds;
                        if (artistResetCounter > 1000 * (int) Config.GetEntry("waitingTime"))
                        {
                            artistPosition.X -= ((int) Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                            artistResetCounter = 0;
                        }
                    }
                    else
                    {
                        artistPosition.X -= ((int) Config.GetEntry("scrollSpeed") / 100f) * (float)gameTime.ElapsedGameTime.Milliseconds;
                    }
                }
                else
                {
                    artistPosition.X = 860 - artistSize.X;
                    artistResetCounter += gameTime.ElapsedGameTime.Milliseconds;
                    if (artistResetCounter > 1000 * (int) Config.GetEntry("waitingTime"))
                    {
                        artistPosition.X = 40;
                        artistResetCounter = 0;
                    }
                }
            }
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
                spriteBatch.DrawString(exo2SemiBoldItalic, titleOutput, titlePosition, Color.White);
                if (bmEntry.Artist != "" && bmEntry.Creator != "")
                    spriteBatch.DrawString(exo2SemiBoldItalicSmall, artistOutput, artistPosition, Color.White);
            spriteBatch.End();
        }
    }
}
