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

                MonoDisplay.myGUI = gui;
                gui.myGame = game;

                gui.Show();
                game.Run();
            }

        }
    }
}
