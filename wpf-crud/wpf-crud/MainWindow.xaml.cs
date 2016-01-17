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

namespace wpf_crud
{
    public partial class MainWindow : Window
    {
        dbModel context = new dbModel();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var authorViewSource = ((CollectionViewSource)(this.FindResource("authorViewSource")));
            authorViewSource.Source = context.authors.ToList();


            //CollectionViewSource authorsViewSource = ((CollectionViewSource)(this.FindResource("authorsViewSource")));
            //authorsViewSource.Source = context.authors.ToList();

            //CollectionViewSource publishersViewSource = ((CollectionViewSource)(this.FindResource("publishersViewSource")));
            //publishersViewSource.Source = context.publishers.ToList();

            //CollectionViewSource titlesViewSource = ((CollectionViewSource)(this.FindResource("titlesViewSource")));
            //titlesViewSource.Source = context.titles.ToList();
        }
        private void CreateAuthor(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateAuthor(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAuthor(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePublisher(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatePublisher(object sender, RoutedEventArgs e)
        {

        }

        private void DeletePublisher(object sender, RoutedEventArgs e)
        {

        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBook(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {

        }
    }
}
