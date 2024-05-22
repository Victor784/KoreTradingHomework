using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WinFormsKoreTrading.Model;
using System.ComponentModel;

using Timer = System.Windows.Forms.Timer;

namespace WinFormsKoreTrading.Services
{
    public class PersonUpdator
    {
        private BindingList<Person> _persons;
        private Timer _occupationTimer;
        private Timer _cityTimer;
        private static Random _random = new Random();

        private static string[] _occupations = { "Engineer", "Doctor", "Artist", "Teacher", "Trader", "Tester" };
        private static string[] _cities = { "Bucuresti", "Cluj-Napoca", "Chicago", "Houston", "New-York" };


        public PersonUpdator(BindingList<Person> persons)
        {
            _persons = persons;
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            _occupationTimer = new Timer();
            _occupationTimer.Interval = 100; // 10 times per second
            _occupationTimer.Tick += (sender, e) => UpdateOccupations(); ;
            _occupationTimer.Start();

            _cityTimer = new Timer();
            _cityTimer.Interval = 250; // 4 times per second
            _cityTimer.Tick += (sender, e) => UpdateCities();
            _cityTimer.Start();
        }

        private void UpdateOccupations()
        {
            //TODO use map instead of foreach or a linq
            foreach (var person in _persons)  
            {
                person.Occupation = _occupations[_random.Next(_occupations.Length)];
            }
        }

        private void UpdateCities()
        {
            foreach (var person in _persons)
            {
                person.City = _cities[_random.Next(_cities.Length)];
            }
        }
    }
}
