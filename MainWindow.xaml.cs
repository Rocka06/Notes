using System.Windows;
using System.Windows.Input;

namespace Notes
{
    public partial class MainWindow : Window
    {
        private List<Note> m_Notes = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
            HandleLang();
        }

        private void LoadNotes()
        {
            m_Notes = Note.LoadNotes();
            NoteList.ItemsSource = m_Notes;
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            string title = NewNoteTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show(Notes.Language.GetLanguage(Settings.SelectedLanguage).EmptyError);
                return;
            }

            if (m_Notes.Any(n => n.Title == title))
            {
                MessageBox.Show(Notes.Language.GetLanguage(Settings.SelectedLanguage).ExistError);
                return;
            }

            m_Notes.Add(new Note { Title = title, Content = "" });
            Note.SaveNotes(m_Notes);
            NewNoteTitle.Clear();
            LoadNotes();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new();
            settingsWindow.ShowDialog();
            LoadNotes();
            HandleLang();
        }
        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (NoteList.SelectedItem == null) return;

            m_Notes.Remove((Note)NoteList.SelectedItem);
            Note.SaveNotes(m_Notes);
            LoadNotes();
        }

        private void NoteList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (NoteList.SelectedItem is Note note)
            {
                EditorWindow editor = new(note);
                editor.ShowDialog();
                Note.SaveNotes(m_Notes);
                LoadNotes();
            }
        }

        private void HandleLang()
        {
            Language language = Notes.Language.GetLanguage(Settings.SelectedLanguage);

            Title = language.Save;
            NewNoteButton.Content = language.AddNote;
            SettingsButton.Content = language.Settings;
            DeleteButton.Content = language.Delete;
        }

        private void NoteList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = NoteList.SelectedItem is Note;
        }
    }
}