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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HuffmanLibrary;
using Microsoft.Win32;
using System.IO;

namespace HuffmanProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        WindowChangeAlphaber WindowChangeAlphabet;
        TextBox textbox_text = null;
        TextBox textbox_encodetext = null;
        Huffman Huffman { get; set; }
        Settings Settings = new Settings();

        private void textBox_textChanged(object sender, TextChangedEventArgs e)
        {
            textbox_encodetext.Text = Huffman.Encode(textbox_text.Text);
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            mi_newfile_Click(sender, e);
            Settings = Settings.Load();
            Settings.LoadAlphabet();
            if (Settings.CheckAlphabet())
            {
                Huffman = new Huffman(Settings.LoadCodeCombinations());
            }
            else
            {
                Huffman = new Huffman(Settings.Alphabet);
                Settings.SaveCodeCombinations(Huffman.CodeCombinations);
                Settings.SaveAlphabet();
                Settings.Save(Settings);
            }
        }
        

        private void mi_savefile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter file = new System.IO.StreamWriter(dialog.FileName))
                {
                    file.WriteLine(Huffman.Encode(textbox_text.Text));
                }
            }
        }

        private void mi_openfile_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabitem = null;
            Grid tabitem_grid = null;


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

               textbox_text = new TextBox();
                textbox_text.TextWrapping = TextWrapping.Wrap;
                textbox_text.AcceptsReturn = true;
                textbox_text.TextChanged += new TextChangedEventHandler(textBox_textChanged);
                textbox_encodetext = new TextBox();
                textbox_encodetext.TextWrapping = TextWrapping.Wrap;
                textbox_encodetext.AcceptsReturn = true;

                tabitem_grid = new Grid();
                tabitem_grid.RowDefinitions.Add(new RowDefinition());
                tabitem_grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(textbox_encodetext, 1);
                tabitem_grid.Children.Add(textbox_text);
                tabitem_grid.Children.Add(textbox_encodetext);

                tabitem = new TabItem();
                tabitem.Header = filename;
                tabitem.Content = tabitem_grid;
                tabControl_files.Items.Add(tabitem);
                tabControl_files.SelectedItem = tabitem;
                using (StreamReader file = new StreamReader(dialog.FileName))
                {
                    textbox_text.Text = Huffman.Decode(file.ReadLine());

                }
            }
            catch { }
        }

        private void mi_newfile_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabitem = null;
            Grid tabitem_grid = null;

            try
            {
                textbox_text = new TextBox();
                textbox_text.TextWrapping = TextWrapping.Wrap;
                textbox_text.AcceptsReturn = true;
                textbox_text.TextChanged += new TextChangedEventHandler(textBox_textChanged);
                textbox_encodetext = new TextBox();
                textbox_encodetext.TextWrapping = TextWrapping.Wrap;
                textbox_encodetext.AcceptsReturn = true;
                
                tabitem_grid = new Grid();
                tabitem_grid.RowDefinitions.Add(new RowDefinition());
                tabitem_grid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(textbox_encodetext, 1);
                tabitem_grid.Children.Add(textbox_text);
                tabitem_grid.Children.Add(textbox_encodetext);
                
                tabitem = new TabItem();
                tabitem.Header = "Untitled";
                tabitem.Content = tabitem_grid;
                tabControl_files.Items.Add(tabitem);
                tabControl_files.SelectedItem = tabitem;
            }
            catch { }
        }

        private void mi_changeAlphabet_Click(object sender, RoutedEventArgs e)
        {
            WindowChangeAlphabet = new WindowChangeAlphaber();
            WindowChangeAlphabet.Owner = this;
            WindowChangeAlphabet.ShowDialog();
            if(WindowChangeAlphabet.DialogResult.HasValue && WindowChangeAlphabet.DialogResult.Value)
            {
                Settings.Alphabet = WindowChangeAlphabet.Alphabet;
                Huffman = new Huffman(Settings.Alphabet);
                Settings.SaveCodeCombinations(Huffman.CodeCombinations);
                Settings.SaveAlphabet();
                Settings.Save(Settings);
            }
    }
    }
}
