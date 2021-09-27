namespace NP.Demos.AccessPropertiesInXamlSample
{
    public class Person
    {
        public int AgeInYears { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"Person: {FirstName} {LastName}, Age: {AgeInYears}";
        }
    }
}
