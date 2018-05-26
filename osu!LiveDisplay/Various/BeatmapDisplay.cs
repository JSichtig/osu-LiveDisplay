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

        Dictionary<string, ScrollableText> scrollableTexts;

        Effect curvedBorder;
        Effect textCutOff;

        int switchCounter = 0;

        public BeatmapDisplay(GraphicsDevice gd, ContentManager content, BeatmapEntry bmEntry)
        {
            this.bmEntry = bmEntry;
            this.gd = gd;
            spriteBatch = new SpriteBatch(gd);
            this.content = content;

            curvedBorder = content.Load<Effect>("border-radius");
            curvedBorder.Parameters["MaskTexture"].SetValue(content.Load<Texture2D>("MaskTexture"));
            textCutOff = content.Load<Effect>("TextCutoff");

            scrollableTexts = new Dictionary<string, ScrollableText>();

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

            scrollableTexts.Add("titleText",new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalic"), bmEntry.Title + ((bmEntry.Version == "") ? "" : " [" + bmEntry.Version + "]"), new Vector2(40, 20)));
            scrollableTexts.Add("artistText",new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalicSmall"), bmEntry.Artist + " // " + bmEntry.Creator, new Vector2(40, 66)));

            if (bmEntry.Artist == "" && bmEntry.Creator == "")
                scrollableTexts["artistText"].Text = "";

            // let's build the info for the stats display
            // top line:    length, BPM, stars
            // bottom line: CS, AR, OD, HP

            string topLineText = $"Drain: {formatLength(bmEntry.DrainTimeSeconds)}  BPM: {formatBPM(bmEntry.TimingPoints)}  Stars: {Math.Round(bmEntry.DiffStarRatingStandard[Mods.None],2)}";
            string bottomLineText = $"CS: {bmEntry.CircleSize}  AR: {bmEntry.ApproachRate}  OD: {bmEntry.OveralDifficulty}  HP: {bmEntry.HPDrainRate}";

            scrollableTexts.Add("statsTopText",new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalic"), topLineText, new Vector2(40,20)));
            scrollableTexts.Add("statsBottomText", new ScrollableText(this.gd, content.Load<SpriteFont>("Exo2SemiBoldItalicSmall"), bottomLineText, new Vector2(40, 66)));

            // visibility test
            scrollableTexts["statsTopText"].Visible = false;
            scrollableTexts["statsBottomText"].Visible = false;
            scrollableTexts["statsTopText"].Active = false;
            scrollableTexts["statsBottomText"].Active = false;
        }

        private string formatLength(int s)
        {
            return (s - (s %= 60)) / 60 + (9 < s ? ":" : ":0") + s;
        }

        private string formatBPM(List<TimingPoint> timingPoints)
        {
            // sort highest to lowest
            timingPoints.Sort((tp1, tp2) => tp2.MsPerQuarter.CompareTo(tp1.MsPerQuarter));
            // remove negatives
            timingPoints.RemoveAll((tp) => tp.MsPerQuarter < 0);
            // remove duplicates
            List<TimingPoint> timingPointsNoDupes = timingPoints.Distinct().ToList();
            // get highest and lowest!
            if (timingPointsNoDupes.Count > 1)
                return $"{Math.Round(60000 / timingPointsNoDupes.First().MsPerQuarter, 0)}-{Math.Round(60000 / timingPointsNoDupes.Last().MsPerQuarter, 0)}";
            else
                return $"{Math.Round(60000 / timingPointsNoDupes.First().MsPerQuarter, 0)}";
        }

        private void switchDisplay(GameTime gameTime)
        {
            switchCounter += gameTime.ElapsedGameTime.Milliseconds;
            if(switchCounter > (int) Config.GetEntry("switchDisplayed") * 1000)
            {
                foreach (KeyValuePair<string, ScrollableText> pair in scrollableTexts)
                {
                    pair.Value.Visible = !pair.Value.Visible;
                    pair.Value.Active = !pair.Value.Active; // we want to "freeze" scrolling texts!
                }   
                switchCounter = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            switchDisplay(gameTime);
            foreach (KeyValuePair<string, ScrollableText> pair in scrollableTexts)
                pair.Value.Update(gameTime);
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
            foreach (KeyValuePair<string, ScrollableText> pair in scrollableTexts)
                pair.Value.Draw(gameTime,spriteBatch);
            spriteBatch.End();
        }
    }

    public class ScrollableText
    {
        GraphicsDevice graphicsDevice;

        SpriteFont font;
        string text;
        public string Text
        {
            set { text = value; }
            get { return text; }
        }
        Vector2 position;
        Vector2 size;
        int resetCounter = 0;

        private bool visible = true;
        public bool Visible
        {
            set { visible = value; }
            get { return visible; }
        }
        private bool active = true;
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }

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
            if (!Active)
                return;

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
            if(Visible)
                spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
