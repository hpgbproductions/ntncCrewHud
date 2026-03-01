using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ntncCrewHud
{
    partial class Form1
    {
        private Dictionary<string, string> SettingsEntries;

        private const string SettingsFilePath = "settings.txt";
        private const string SettingsRegexPattern = @"^(\w+?)\s*=\s*([\w.]+)\s*";

        /// <summary>
        /// Read the settings file, making them accessible to the program.
        /// </summary>
        public void InitSettings()
        {
            SettingsEntries = new Dictionary<string, string>();
            string[] allLines = File.ReadAllLines(SettingsFilePath);

            foreach (string s in allLines)
            {
                Match match = Regex.Match(s, SettingsRegexPattern, RegexOptions.CultureInvariant);

                if (!match.Success)
                {
                    continue;
                }

                string key = match.Groups[1].Value;
                string val = match.Groups[2].Value;
                SettingsEntries.Add(key, val);
            }
        }

        public bool ReadBool(string key)
        {
            return bool.Parse(SettingsEntries[key]);
        }

        public int ReadInt(string key)
        {
            return int.Parse(SettingsEntries[key]);
        }

        public float ReadFloat(string key)
        {
            return float.Parse(SettingsEntries[key]);
        }
    }
}
