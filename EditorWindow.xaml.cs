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
            m_Note = note;
            Title.Content = m_Note.Title;
            TxtContent.Text = m_Note.Content;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            m_Note.Content = TxtContent.Text;
            MessageBox.Show("Note saved.");
            Close();
        }
    }
}
