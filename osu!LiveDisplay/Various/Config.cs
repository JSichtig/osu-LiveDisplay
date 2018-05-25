using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace osu_LiveDisplay.Various
{
    public class Config
    {
        public static List<Action> OnReadSubs = new List<Action>();

        private static Dictionary<string, object[]> settings;
        public static Dictionary<string, object[]> Settings
        {
            get { return settings; }
        }

        public static void ReadConfig()
        {
            settings = new Dictionary<string, object[]>();

            // Set default config values
            settings["hiddenOnMenu"]    = new object[] { typeof(bool), false };
            settings["scrollSpeed"]     = new object[] { typeof(int), 5 };
            settings["waitingTime"]     = new object[] { typeof(int), 2 };
            settings["osuLocation"]     = new object[] { typeof(string), ""};
            settings["snapToGUI"]       = new object[] { typeof(bool), true };
            settings["isBorderless"]    = new object[] { typeof(bool), false };

            // Read local settings.cfg (if it exists)
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string settingsFile = directory + @"\settings.cfg";

            if (File.Exists(settingsFile))
            {
                StreamReader fileReader = new StreamReader(settingsFile);
                string currentLine;
                while ((currentLine = fileReader.ReadLine()) != null)
                {
                    string key = currentLine.Split(new char[] { ':' }, 2)[0];
                    string value = currentLine.Split(new char[] { ':' }, 2)[1];

                    if (settings[key] == null)
                    {
                        Console.WriteLine($"Tried to init unknown setting: {key} with value {value}. Please check your settings.cfg.");
                        continue;
                    }

                    Type convertTo = (Type)settings[key][0];

                    // try to cast the value to this type
                    SetEntry(key, Convert.ChangeType(value, convertTo));
                }
                fileReader.Close();
            }
            
            // callback the subscribers!
            foreach(Action callbacks in OnReadSubs)
            {
                callbacks();
            }
        }

        public static void SubscribeOnReadEvent(Action action)
        {
            OnReadSubs.Add(action);
        }

        public static object GetEntry(string entry)
        {
            if (settings[entry] == null)
                return null;
            return settings[entry][1];
        }

        public static void SetEntry(string entry, object value)
        {
            if (settings[entry] == null)
                return;
            settings[entry][1] = value;
        }

        public static void SaveSettings()
        {
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string settingsFile = directory + @"\settings.cfg";

            using (StreamWriter writer = new StreamWriter(settingsFile, false))
            {
                foreach(KeyValuePair<string, object[]> kvPair in settings)
                {
                    writer.WriteLine($"{kvPair.Key}:{kvPair.Value[1]}");
                }
            }
        }
    }
}
