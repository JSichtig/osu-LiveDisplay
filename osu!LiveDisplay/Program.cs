using osu_LiveDisplay.Various;
using System;

namespace osu_LiveDisplay
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using(var game = new MonoDisplay())
            {
                var gui = new MainGUI();
                Config.SubscribeOnReadEvent(gui.OnConfigRead);
                gui.myGame = game;
                gui.Initialize();
                gui.Show();
                game.Run();
            }
        }
    }
}
