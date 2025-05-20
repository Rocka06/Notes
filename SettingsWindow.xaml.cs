using Microsoft.Win32;
using System.Windows;

namespace Notes
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            HandleLang();

            LanguageSelect.ItemsSource = Notes.Language.Languages.Keys;
            LanguageSelect.SelectedItem = Settings.SelectedLanguage;
            txtPath.Text = Settings.SavePath;
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                FileName = "notes.json",
                Filter = "JSON files (*.json)|*.json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                txtPath.Text = saveFileDialog.FileName;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Settings.SavePath = txtPath.Text;
            Settings.SelectedLanguage = LanguageSelect.Text;

            Settings.Save();
            MessageBox.Show(Notes.Language.GetLanguage(Settings.SelectedLanguage).Saved);
            Close();
        }

        private void HandleLang()
        {
            Language language = Notes.Language.GetLanguage(Settings.SelectedLanguage);

            Title = language.Save;
            BrowseButton.Content = language.Browse;
            SaveButton.Content = language.Save;
            LangLabel.Content = language.LangLabel;
            PathLabel.Content = language.PathLabel;
        }
    }
}
