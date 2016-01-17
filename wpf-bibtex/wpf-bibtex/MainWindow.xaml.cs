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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_bibtex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BiblioItem> BibliotItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BibliotItems = new List<BiblioItem>();
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            // will try to open from path from text box
            // if no file exists - continues to open file dialog
            if (File.Exists(pathBox.Text))
            {
                //AnalyzeDll(pathBox.Text);
                return;
            }

            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                pathBox.Text = openFileDialog.FileName;
                //AnalyzeDll(pathBox.Text);
            }
        }
    }
}
