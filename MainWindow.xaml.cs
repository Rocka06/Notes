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
                MessageBox.Show("Note title cannot be empty.");
                return;
            }

            if (m_Notes.Any(n => n.Title == title))
            {
                MessageBox.Show("Note with this title already exists.");
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

        private void NoteList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = NoteList.SelectedItem is Note;
        }
    }
}