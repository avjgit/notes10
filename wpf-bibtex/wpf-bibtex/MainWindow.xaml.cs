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
        public List<BOOK> Books { get; set; }
        public List<ARTICLE> Articles { get; set; }
        public List<Thesis> Masters { get; set; }
        public List<Thesis> PhDs { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            Books = new List<BOOK>();
            Articles = new List<ARTICLE>();
            Masters = new List<Thesis>();
            PhDs = new List<Thesis>();

            // debug
            Books.Add(new BOOK("John Tolkien", "The Hobbit", "George Allen & Unwin", 1937, "UK"));

            Masters.Add(new Thesis("Sergey", "Brin", "The Anatomy of a Large-Scale Hypertextual Web Search Engine", 
                Thesis.ThesisType.MASTERSTHESIS, "Stanford", 1995));

            PhDs.Add(new Thesis("Richard", "Feynman", "The Principle of Least Action in Quantum Mechanics",
                Thesis.ThesisType.PHDTHESIS, "Princeton University", 1942));

            Articles.Add(new ARTICLE("Bob Woodward, Carl Bernstein", "Investigation of the Watergate break in", 1970,
                "Washington Post", "1"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var bOOKViewSource = ((CollectionViewSource)(this.FindResource("bOOKViewSource")));
            bOOKViewSource.Source = Books;

            var aRTICLEViewSource = ((CollectionViewSource)(this.FindResource("aRTICLEViewSource")));
            aRTICLEViewSource.Source = Articles;

            var thesisViewSource = ((CollectionViewSource)(this.FindResource("thesisViewSource")));
            thesisViewSource.Source = Masters;

            mastersDataGrid.ItemsSource = Masters;

            phdsDataGrid.ItemsSource = PhDs;
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

        private void CreateBook(object sender, RoutedEventArgs e)
        {
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {

        }

        private void CreateMaster(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteMaster(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePhd(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePhd(object sender, RoutedEventArgs e)
        {

        }

        private void CreateArticle(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteArticle(object sender, RoutedEventArgs e)
        {

        }
    }
}
