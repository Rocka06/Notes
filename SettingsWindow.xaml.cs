using Microsoft.Win32;
using System.Windows;

namespace Notes
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
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
            Settings.Save();
            MessageBox.Show("Settings saved.");
            Close();
        }
    }
}
