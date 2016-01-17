using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Configuration;

namespace wpf_crud
{
    public partial class MainWindow : Window
    {
        dbModel context = new dbModel();

        public MainWindow()
        {
            InitializeComponent();
            Title = "AJ05044 Homework2: connected to " + ConfigurationManager.ConnectionStrings["hw2db"].ConnectionString;
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

        // common method for author and publisher
        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();

                MessageBox.Show(
                    $"All changes successfully saved",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error during saving pending changes: {ex.InnerException}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateButtonState(Button create, Button update, Button delete)
        {
            create.IsEnabled = false;
            update.IsEnabled = true;
            delete.IsEnabled = true;
        }

        private void CreateAuthor(object sender, RoutedEventArgs e)
        {
            var newAuthor = authorDataGrid.SelectedItem as author;
            if (newAuthor == null || newAuthor.au_id != null) return;
            newAuthor.au_id = GetAuthorId();
            newAuthor.phone = "1188"; //hardcoding required field, as allowed per requirements
            context.authors.Add(newAuthor);

            try
            {
                context.SaveChanges();
                UpdateButtonState(createAuthorBtn, updateAuthorBtn, deleteAuthorBtn);

                MessageBox.Show(
                    $"Author {newAuthor.FullName} successfully created", 
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to save following entry to database:
id: {newAuthor.au_id}
firstname: {newAuthor.au_fname}
lastname: {newAuthor.au_lname}
exception: {ex.InnerException}
",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetAuthorId()
        {
            string id = string.Empty;
            for (int i = 0; i <= 999999999; i++)
            {
                var idString = i.ToString("D9");

                var idPrefix = idString.Substring(0,3);
                var idMiddle = idString.Substring(3,2);
                var idSuffix = idString.Substring(5,4);

                id = $"{idPrefix}-{idMiddle}-{idSuffix}";

                if (!context.authors.Where(a => a.au_id == id).Any())
                    break;
            }
            return id;
        }

        private void DeleteAuthor(object sender, RoutedEventArgs e)
        {
            var author = authorDataGrid.SelectedItem as author;

            if (author == null) return;

            if (author.au_id != null)
            {
                var removable = context.authors.Single(a => a.au_id == author.au_id);
                context.authors.Remove(removable);
            }

            try
            {
                context.SaveChanges();
                authorDataGrid.ItemsSource = context.authors.ToList();
                UpdateButtonState(createAuthorBtn, updateAuthorBtn, deleteAuthorBtn);
                MessageBox.Show(
                    $"Author {author.FullName} successfully removed",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to remove {author.FullName}. Exception: {ex.InnerException}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreatePublisher(object sender, RoutedEventArgs e)
        {
            var newPublisher = publisherDataGrid.SelectedItem as publisher;
            if (newPublisher == null || newPublisher.pub_id != null) return;
            newPublisher.pub_id = GetPublsherId();

            try
            {
                context.publishers.Add(newPublisher);
                context.SaveChanges();
                UpdateButtonState(createPublisherBtn, updatePublisherBtn, deletePublisherBtn);

                MessageBox.Show(
                    $"Publisher {newPublisher.pub_name} successfully created",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to save following entry to database:
id: {newPublisher.pub_id}
name: {newPublisher.pub_name}
exception: {ex.InnerException}
",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

            if (publisher == null) return;

            if (publisher.pub_id != null)
            {
                var removable = context.publishers.Single(x => x.pub_id == publisher.pub_id);
                context.publishers.Remove(publisher);
            }

            try
            {
                context.SaveChanges();
                publisherDataGrid.ItemsSource = context.publishers.ToList();
                UpdateButtonState(createPublisherBtn, updatePublisherBtn, deletePublisherBtn);

                MessageBox.Show(
                    $"Publisher {publisher.pub_name} successfully removed",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to remove {publisher.pub_name}. Exception: {ex.InnerException}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {
            var newTitle = titleDataGrid.SelectedItem as title;
            if (newTitle == null || newTitle.title_id != null) return;
            newTitle.type = "fiction";
            newTitle.title_id = GetBooksId();

            newTitle.pub_id = publisherComboBox.SelectedValue?.ToString();

            try
            {
                context.titles.Add(newTitle);
                context.SaveChanges();
                UpdateButtonState(createBookBtn, updateBookBtn, deleteBookBtn);

                foreach (author author in authorListBox.SelectedItems)
                {
                    var entry = new titleauthor
                    {
                        title_id = newTitle.title_id,
                        au_id = author.au_id
                    };
                    
                    newTitle.titleauthors.Add(entry);
                }
                context.SaveChanges();

                MessageBox.Show(
                    $"Book {newTitle.title1} successfully created",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to save following entry to database:
id: {newTitle.title_id}
name: {newTitle.title1}
exception: {ex.InnerException}
",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string GetBooksId()
        {
            string id = string.Empty;
            for (int i = 0; i <= 999999; i++)
            {
                id = i.ToString("D6");
                if (!context.titles.Where(x => x.title_id == id).Any())
                    break;
            }
            return id;
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            var book = titleDataGrid.SelectedItem as title;

            if (book == null) return;

            if (book.title_id != null)
            {
                var removable = context.titles.Single(x => x.title_id == book.title_id);
                context.titles.Remove(book);
            }

            try
            {
                context.SaveChanges();
                titleDataGrid.ItemsSource = context.titles.ToList();
                UpdateButtonState(createPublisherBtn, updatePublisherBtn, deletePublisherBtn);

                MessageBox.Show(
                    $"Publisher {book.title1} successfully removed",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error trying to remove {book.title1}. Exception: {ex.InnerException}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateBook(object sender, RoutedEventArgs e)
        {
            var selectedBook = titleDataGrid.SelectedItem as title;

            if (selectedBook.title_id == null) return;

            var book = context.titles.Single(t => t.title_id == selectedBook.title_id);
            context.Entry(book).State = EntityState.Modified;
            
            // update publisher
            book.pub_id = publisherComboBox.SelectedValue?.ToString();

            // update authors
            book.titleauthors.Clear();
            foreach (author author in authorListBox.SelectedItems)
            {
                var entry = new titleauthor
                {
                    title_id = book.title_id,
                    au_id = author.au_id
                };

                book.titleauthors.Add(entry);
            }

            try
            {
                // save changes in books' fields
                context.SaveChanges();
                titleDataGrid.Items.Refresh();

                MessageBox.Show(
                    $"All changes for {book.title1} successfully saved",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Error during saving pending changes for {book.title1}: {ex.InnerException}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void booksSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var book = titleDataGrid.SelectedItem as title;

            // synchronize books details

            // disable creation button if entry is not new
            createBookBtn.IsEnabled = (book == null || book.title_id == null);
            updateBookBtn.IsEnabled = (book != null && book.title_id != null);
            deleteBookBtn.IsEnabled = (book != null);

            if (book == null)
            {
                publisherComboBox.SelectedIndex = -1;
                authorListBox.SelectedItems.Clear();
                return;
            }

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

        private void authorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var author = authorDataGrid.SelectedItem as author;
            createAuthorBtn.IsEnabled = (author == null || author.au_id == null);
            updateAuthorBtn.IsEnabled = (author != null && author.au_id != null);
            deleteAuthorBtn.IsEnabled = (author != null);
        }
        private void publishersSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var publisher = publisherDataGrid.SelectedItem as publisher;
            createPublisherBtn.IsEnabled = (publisher == null || publisher.pub_id == null);
            updatePublisherBtn.IsEnabled = (publisher != null && publisher.pub_id != null);
            deletePublisherBtn.IsEnabled = (publisher != null);
        }
    }
}
