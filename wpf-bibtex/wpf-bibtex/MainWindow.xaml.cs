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
        public List<BiblioItem> BiblioItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BiblioItems = new List<BiblioItem>();

            // debug
            var testbook = new BOOK("John Tolkien", "The Hobbit", "George Allen & Unwin", 1937, "UK");

            var testMaster = new Thesis("Sergey", "Brin", "The Anatomy of a Large-Scale Hypertextual Web Search Engine", 
                Thesis.ThesisType.MASTERSTHESIS, "Stanford", 1995);

            var testPhd = new Thesis("Richard", "Feynman", "The Principle of Least Action in Quantum Mechanics",
                Thesis.ThesisType.PHDTHESIS, "Princeton University", 1942);

            var testArticle = new ARTICLE("Bob Woodward, Carl Bernstein", "Investigation of the Watergate break in", 1970,
                "Washington Post", "1");

            BiblioItems.Add(testbook);
            BiblioItems.Add(testMaster);
            BiblioItems.Add(testPhd);
            BiblioItems.Add(testArticle);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var bOOKViewSource = ((CollectionViewSource)(this.FindResource("bOOKViewSource")));
            bOOKViewSource.Source = BiblioItems.Where(x => x.GetType() == typeof(BOOK)).ToList();

            var aRTICLEViewSource = ((CollectionViewSource)(this.FindResource("aRTICLEViewSource")));
            aRTICLEViewSource.Source = BiblioItems.Where(x => x.GetType() == typeof(ARTICLE)).ToList();

            var thesisViewSource = ((CollectionViewSource)(this.FindResource("thesisViewSource")));
            thesisViewSource.Source = BiblioItems.Where(x => x.GetType() == typeof(Thesis));

            mastersDataGrid.ItemsSource = BiblioItems
                .Where(x => x.GetType() == typeof(Thesis))
                .Where(x => ((Thesis)x).Type == Thesis.ThesisType.MASTERSTHESIS)
                .ToList();

            phdsDataGrid.ItemsSource = BiblioItems
                .Where(x => x.GetType() == typeof(Thesis))
                .Where(x => ((Thesis)x).Type == Thesis.ThesisType.PHDTHESIS)
                .ToList();
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
