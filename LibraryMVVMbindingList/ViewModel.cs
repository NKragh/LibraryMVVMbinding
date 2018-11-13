using GalaSoft.MvvmLight.Command;
using LibraryMVVMbindingList.Annotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LibraryMVVMbindingList
{
    class ViewModel : INotifyPropertyChanged
    {

        private string _loaner;

        // her huskes den valgte bog :-)
        private Book _selectedBook;

        // Her gemmes alle bøger - observable coolection betyder at den kan notificere GUI om ændringer
        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public ViewModel()
        {
            _books.Add(new Book("1234567654321-1234", "Ebbe Vang", "Flæskesteg for begyndere"));
            _books.Add(new Book("2345-76543-123", "Lars trOlesen", "Frokost på nye måder"));
            _books.Add(new Book("123456-76543-432", "Lasse Coinbæk", "Bitcoin i Vipperød"));
            _books.Add(new Book("12345-765432-12345", "Michael Kærgården", "Den der smører godt, kører godt - Glæden ved at CYKLE"));

            LoanBookCommand = new RelayCommand(
                addLoanertoSelectedBook);

        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(); // fortæller XAML at property er opdateret
            }
        }

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        public string Loaner
        {
            get { return _loaner; }
            set
            {
                _loaner = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoanBookCommand
        {
            get;
            private set;
        }

        private void addLoanertoSelectedBook()
        {
            Debug.WriteLine("add loaner");
            //Debug.WriteLine("Loaner: " + Loaner);
            //Debug.WriteLine("SelectedBook_: "+ SelectedBook.Title);
            Debug.WriteLine(SelectedBook);
            SelectedBook.Loaner = Loaner;
            //OnPropertyChanged("SelectedBook");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
