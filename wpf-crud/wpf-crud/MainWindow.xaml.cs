using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var authorViewSource = ((CollectionViewSource)(FindResource("authorViewSource")));
            authorViewSource.Source = context.authors.ToList();

            var publisherViewSource = ((CollectionViewSource)(FindResource("publisherViewSource")));
            publisherViewSource.Source = context.publishers.ToList();

            var titleViewSource = ((CollectionViewSource)(FindResource("titleViewSource")));
            titleViewSource.Source = context.titles.ToList();
        }

        // common method for all entities
        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void CreateAuthor(object sender, RoutedEventArgs e)
        {
            var newAuthor = authorDataGrid.SelectedItem as author;

            // to prevent creation of already existing author
            if (newAuthor.au_id != null) return;

            newAuthor.au_id = GetAuthorId();

            //hardcoded required field, as allowed per requirements
            newAuthor.phone = "1188"; 
            context.authors.Add(newAuthor);
            context.SaveChanges();
        }

        private string GetAuthorId()
        {
            string id = string.Empty;
            for (int i = 1111; i <= 9999; i++)
            {
                id = "111-11-" + i.ToString();

                if (!context.authors.Where(a => a.au_id == id).Any())
                    break;
            }
            return id;
        }

        

        private void DeleteAuthor(object sender, RoutedEventArgs e)
        {
            var author = authorDataGrid.SelectedItem as author;
            var removable = context.authors.Single(a => a.au_id == author.au_id);
            context.authors.Remove(removable);
            context.SaveChanges();
            authorDataGrid.ItemsSource = context.authors.ToList();
        }

        private void CreatePublisher(object sender, RoutedEventArgs e)
        {
            var newPublisher = publisherDataGrid.SelectedItem as publisher;
            newPublisher.pub_id = GetPublsherId();
            context.publishers.Add(newPublisher);
            context.SaveChanges();
        }
        private string GetPublsherId()
        {
            string id = string.Empty;
            for (int i = 1; i <= 99; i++)
            {
                id = (9900 + i).ToString();

                if (!context.publishers.Where(x => x.pub_id == id).Any())
                    break;
            }
            return id;
        }

        private void DeletePublisher(object sender, RoutedEventArgs e)
        {
            var publisher = publisherDataGrid.SelectedItem as publisher;
            var removable = context.publishers.Single(x => x.pub_id == publisher.pub_id);
            context.publishers.Remove(publisher);
            context.SaveChanges();
            publisherDataGrid.ItemsSource = context.publishers.ToList();
        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {
            var newTitle = titleDataGrid.SelectedItem as title;
            newTitle.type = "fiction";
            newTitle.title_id = GetBooksId();
            context.titles.Add(newTitle);
            context.SaveChanges();
        }
        private string GetBooksId()
        {
            string id = string.Empty;
            for (int i = 100000; i <= 999999; i++)
            {
                id = i.ToString();
                if (!context.publishers.Where(x => x.pub_id == id).Any())
                    break;
            }
            return id;
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            var book = titleDataGrid.SelectedItem as title;
            var removable = context.titles.Single(x => x.title_id == book.title_id);
            context.titles.Remove(book);
            context.SaveChanges();
            titleDataGrid.ItemsSource = context.titles.ToList();
        }

        private void UpdateBook(object sender, RoutedEventArgs e)
        {
            var selectedBook = titleDataGrid.SelectedItem as title;
            var book = context.titles.Single(t => t.title_id == selectedBook.title_id);
            context.Entry(book).State = EntityState.Modified;

            // check for changes in 
            if (publisherComboBox.SelectedValue != null)
            {
                var selectedPublisherId = publisherComboBox.SelectedValue.ToString();
                if (book.pub_id != selectedPublisherId)
                    book.pub_id = selectedPublisherId;
            }

            // check for changes in authors
            var oldAuthors = book.titleauthors.Select(t => t.au_id).ToList();
            var selectedAuthors = new List<string>();
            foreach (author author in authorListBox.SelectedItems)
                selectedAuthors.Add(author.au_id);

            var removedAuthors = oldAuthors.Except(selectedAuthors);
            var newAuthors = selectedAuthors.Except(oldAuthors);

            foreach (var id in removedAuthors)
            {
                var entry = book.titleauthors.Single(t => t.au_id == id);
                book.titleauthors.Remove(entry);
            }

            foreach (var id in newAuthors)
            {
                var entry = new titleauthor { title_id = book.title_id, au_id = id };
                book.titleauthors.Add(entry);
            }

            // save changes in books' fields
            context.SaveChanges();
            titleDataGrid.Items.Refresh();
        }

        private void SynchronizeBookDetails(object sender, SelectionChangedEventArgs e)
        {
            var book = titleDataGrid.SelectedItem as title;

            // sync publisher dropdown
            publisherComboBox.SelectedValue = book.pub_id;

            // sync authors dropdown
            if (authorListBox.SelectedItems.Count > 0)
                authorListBox.SelectedItems.Clear();

            foreach (var authorId in book.titleauthors.Select(x => x.au_id))
            {
                var author = context.authors.Single(a => a.au_id == authorId);
                var authorItemIndex = authorListBox.Items.IndexOf(author);
                var authorItem = authorListBox.Items.GetItemAt(authorItemIndex);
                authorListBox.SelectedItems.Add(authorItem);
            }
        }
    }
}
