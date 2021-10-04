using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NP.Demos.ItemsPresenterSample
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // fires notification if a property changes
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // collection of PersonViewModel objects
        public ObservableCollection<PersonViewModel> People { get; } =
            new ObservableCollection<PersonViewModel>();

        // number of people
        public int NumberOfPeople => People.Count;

        public TestViewModel()
        {
            People.CollectionChanged += People_CollectionChanged;

            People.Add(new PersonViewModel("Joe", "Doe"));
            People.Add(new PersonViewModel("Jane", "Dane"));
            People.Add(new PersonViewModel("John", "Dawn"));
        }

        // whenever collection changes, fire notification for possible updates
        // of NumberOfPeople and CanRemoveLast properties.
        private void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(NumberOfPeople));
            OnPropertyChanged(nameof(CanRemoveLast));
        }

        // can remove last item only if collection has some items in it
        public bool CanRemoveLast => NumberOfPeople > 0;

        // remove last item of the collection
        public void RemoveLast()
        {
            People.RemoveAt(NumberOfPeople - 1);
        }
    }
}
