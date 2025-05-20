using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notes
{
    public partial class EditorWindow : Window
    {
        Note m_Note;

        public EditorWindow(Note note)
        {
            InitializeComponent();
            HandleLang();
            m_Note = note;
            TitleTxt.Content = m_Note.Title;
            TxtContent.Text = m_Note.Content;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            m_Note.Content = TxtContent.Text;
            MessageBox.Show(Notes.Language.GetLanguage(Settings.SelectedLanguage).Saved);
            Close();
        }

        private void HandleLang()
        {
            Language language = Notes.Language.GetLanguage(Settings.SelectedLanguage);

            Title = language.Editor;
            SaveButton.Content = language.Save;
        }
    }
}
