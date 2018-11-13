using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryMVVMbindingList.Annotations;

namespace LibraryMVVMbindingList
{
    class Book : INotifyPropertyChanged
    {
        private string _isbn;
        private string _author;
        private string _title;
        private string _loaner;

        public Book(String isbn, string author, string title)
        {
            _author = author;
            _isbn = isbn;
            _title = title;
        }

        public string Isbn
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("title:");
            sb.Append(Title);
            sb.Append("\n");
            sb.Append("loaner:");
            sb.Append(Loaner);
            return sb.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}