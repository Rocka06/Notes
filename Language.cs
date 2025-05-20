using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    class Language
    {
        public static Dictionary<string, Language> Languages = new();
        static Language()
        {
            Languages.Add("en", new Language()
            {
                Save = "Save",
                Editor = "Editor",
                Settings = "Settings",
                Notes = "Notes",
                Browse = "Browse",
                AddNote = "Add Note",
                Delete = "Delete",
                ExistError = "Note with this title already exists",
                EmptyError = "Note title cannot be empty",
                Saved = "Saved",
                LangLabel = "Language:",
                PathLabel = "Save Path:"
            });

            Languages.Add("hu", new Language()
            {
                Save = "Mentés",
                Editor = "Szerkesztő",
                Settings = "Beállítások",
                Notes = "Jegyzetek",
                Browse = "Tallózás",
                AddNote = "Új jegyzet",
                Delete = "Törlés",
                ExistError = "Ilyen című jegyzet már létezik",
                EmptyError = "A jegyzet neve nem lehet üres",
                Saved = "Sikeres mentés",
                LangLabel = "Nyelv:",
                PathLabel = "Mentési hely:"
            });
        }

        public string Save, Editor, Settings, Notes, Browse, AddNote, Delete, EmptyError, ExistError, Saved, LangLabel, PathLabel;
    
        public static Language GetLanguage(string lang)
        {
            if (Languages.ContainsKey(lang))
            {
                return Languages[lang];
            }

            return Languages["en"];
        }
    }
}
