using WinFormsKoreTrading.Model;

namespace WinFormsKoreTrading.Services
{
    public class PersonGenerator
    {
        private static Random _random = new Random();
        private static string[] _firstNames = { "John", "Jane", "Alex", "Emily" }; 
        private static string[] _lastNames = { "Doe", "Smith", "Johnson", "Williams" };
        private static string[] _occupations = { "Engineer", "Doctor", "Artist", "Teacher", "Trader", "Tester"};
        private static string[] _cities = { "Bucuresti", "Cluj-Napoca", "Chicago", "Houston" , "New-York"};
        private static string[] _genders = { "Male", "Female" };

        public static List<Person> GeneratePersons(int count)
        {
            var persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var person = new Person
                {
                    Name = $"{_firstNames[_random.Next(_firstNames.Length)]} {_lastNames[_random.Next(_lastNames.Length)]}",
                    Age = _random.Next(11, 60),
                    Occupation = _occupations[_random.Next(_occupations.Length)],
                    Gender = _genders[_random.Next(_genders.Length)],
                    City = _cities[_random.Next(_cities.Length)]
                };

                persons.Add(person);
            }

            return persons;
        }
    }
}
