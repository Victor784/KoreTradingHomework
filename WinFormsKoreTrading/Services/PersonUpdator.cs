using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WinFormsKoreTrading.Model;
using System.ComponentModel;

using Timer = System.Windows.Forms.Timer;
using System.Collections.Concurrent;

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

        //Enqueueing the new data and triggering a refresh for all elements 
        private ConcurrentQueue<Action> _updateQueue = new ConcurrentQueue<Action>();
        private Control _uiControl;
        public PersonUpdator(BindingList<Person> persons, Control uiControl)
        {
            _persons = persons;
            _uiControl = uiControl;
            InitializeTimers();
        }

        public void SetUIControl(Control uiControl)
        {
            _uiControl = uiControl;
        }

        private void InitializeTimers()
        {
            _occupationTimer = new Timer();
            _occupationTimer.Interval = 100; // 10 times per second
            _occupationTimer.Tick += (sender, e) => QueueOccupationUpdates(); ;
            _occupationTimer.Start();

            _cityTimer = new Timer();
            _cityTimer.Interval = 250; // 4 times per second
            _cityTimer.Tick += (sender, e) => QueueCityUpdates();
            _cityTimer.Start();
        }

        private void QueueOccupationUpdates()
        {
            foreach (var person in _persons)
            {
                var occupation = _occupations[_random.Next(_occupations.Length)];
                _updateQueue.Enqueue(() => person.Occupation = occupation);
            }
            ProcessQueue();
        }

        private void QueueCityUpdates()
        {
            foreach (var person in _persons)
            {
                var city = _cities[_random.Next(_cities.Length)];
                _updateQueue.Enqueue(() => person.City = city);
            }
            ProcessQueue();
        }

        private void ProcessQueue()
        {
            // Process all items in the queue
            while (_updateQueue.TryDequeue(out var updateAction))
            {
                updateAction();
            }

            // Update the UI on the UI thread
            _uiControl.BeginInvoke((Action)(() =>
            {
                // This will trigger the DataGridView to refresh its display
                _persons.ResetBindings();
            }));
        }
    }
}
