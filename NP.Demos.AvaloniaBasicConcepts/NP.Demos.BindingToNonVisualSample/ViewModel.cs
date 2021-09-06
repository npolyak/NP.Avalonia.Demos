using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NP.Demos.BindingToNonVisualSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // collection of names
        public ObservableCollection<string> Names { get; } = new ObservableCollection<string>();

        // number of names
        public int NamesCount => Names.Count;

        // true if there are some names in the collection,
        // false otherwise
        public bool HasItems => NamesCount > 0;

        public ViewModel()
        {
            Names.CollectionChanged += Names_CollectionChanged;
        }

        private void Names_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Change Notification for Avalonia for properties
            // NamesCount and HasItems
            OnPropertyChanged(nameof(NamesCount));
            OnPropertyChanged(nameof(HasItems));
        }
    }
}
