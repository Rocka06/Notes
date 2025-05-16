using System.IO;
using System.Text.Json;

namespace Notes
{
    public class Note
    {
        public required string Title { get; set; }
        public required string Content { get; set; }

        public static void SaveNotes(IEnumerable<Note> notes)
        {
            var json = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Settings.SavePath, json);
        }

        public static List<Note> LoadNotes()
        {
            if (!File.Exists(Settings.SavePath)) return [];
            string json = File.ReadAllText(Settings.SavePath);
            
            return JsonSerializer.Deserialize<List<Note>>(json) ?? [];
        }
    }
}
