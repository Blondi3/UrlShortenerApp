using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortenerApp.Core
{
    public abstract class ObservableProperty : INotifyPropertyChanged
    {
        public ObservableProperty()
        {
            PropertyChanged += OnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
