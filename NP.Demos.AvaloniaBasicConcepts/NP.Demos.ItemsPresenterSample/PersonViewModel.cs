namespace NP.Demos.ItemsPresenterSample
{
    // very simple view model
    public class PersonViewModel
    {
        public string FirstName { get; }

        public string LastName { get; }

        public PersonViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
