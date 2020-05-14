using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {

        private string query;

        public string Query
        {
            get { return query; }
            set { 
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions currentconditions;

        public CurrentConditions currentConditions
        {
            get { return currentconditions; }
            set { 
                currentconditions = value;
                OnPropertyChanged("currentConditions");
            }
        }

        private City selectedcity;

        public City selectedCity
        {
            get { return selectedcity; }
            set { 
                selectedcity = value;
                OnPropertyChanged("selectedCity");
            }
        }

        public async System.Threading.Tasks.Task MakeQueryAsync()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged (string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public SearchCommand SearchCommand { get; set; }

        public WeatherVM()
        {
            //solo se ejecutan en tiempo de diseño
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {

            }

            SearchCommand = new SearchCommand(this);
        }
    }
}
