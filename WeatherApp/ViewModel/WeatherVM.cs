using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {

        private string query;

        public string Query
        {
            get { return Query; }
            set { 
                Query = value;
                OnPropertyChanged(Query);
            }
        }

        private CurrentConditions currentconditions;

        public CurrentConditions currentConditions
        {
            get { return currentConditions; }
            set { 
                currentConditions = value;
                OnPropertyChanged("currentConditions");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
