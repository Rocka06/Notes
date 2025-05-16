using System.IO;
using System.Text.Json;

namespace Notes
{
    public static class Settings
    {
        public static string SavePath { get; set; } = "notes.json";
        private readonly static string m_SettingsFile = "settings.json";

        static Settings()
        {
            Load();
        }

        public static void Load()
        {
            if (!File.Exists(m_SettingsFile)) return;
            
            string json = File.ReadAllText(m_SettingsFile);
            Dictionary<string, string>? data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (data == null) return;

            if (data.ContainsKey("SavePath"))
                SavePath = data["SavePath"];
        }

        public static void Save()
        {
            var data = new Dictionary<string, string> { { "SavePath", SavePath } };
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(m_SettingsFile, json);
        }
    }
}
