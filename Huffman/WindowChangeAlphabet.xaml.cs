using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HuffmanProject
{
    /// <summary>
    /// Interaction logic for WindowChangeAlphaber.xaml
    /// </summary>
    public partial class WindowChangeAlphaber : Window
    {
        public WindowChangeAlphaber()
        {
            InitializeComponent();
        }

        public string Alphabet
        {
            get { return textBox.Text; }
            set
            {
                textBox.Text = value;
            }
        }
        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Text documents (.txt)|*.txt";

                Nullable<bool> result = dialog.ShowDialog();

                if (result == true)
                {
                    filename = dialog.SafeFileName;
                }
                
                using (StreamReader file = new StreamReader(dialog.FileName))
                {
                    Alphabet = file.ReadLine();
                }
            }
            catch { }
        }

        private void btn_change_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        
    }
}
