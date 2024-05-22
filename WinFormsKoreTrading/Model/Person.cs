using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsKoreTrading.Model
{
    public class Person : INotifyPropertyChanged
    {
        private string _occupation;
        private string _city;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation
        {
            get => _occupation;
            set
            {
                if (_occupation != value)
                {
                    _occupation = value;
                    OnPropertyChanged(nameof(Occupation));
                }
            }
        }
        public string Gender { get; set; }
        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
