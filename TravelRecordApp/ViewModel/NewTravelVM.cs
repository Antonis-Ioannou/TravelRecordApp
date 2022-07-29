using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TravelRecordApp.Helpers;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public ObservableCollection<Result> Venues { get; set; }

        public Command SaveCommand { get; set; }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
                OnPropertyChanged("PostIsReady");
            }
        }

        private Result selectedVenue;

        public Result SelectedVenue
        {
            get { return selectedVenue; }
            set
            {
                selectedVenue = value;
                OnPropertyChanged("PostIsReady");
            }
        }

        private bool postIsReady;

        public bool PostIsReady
        {
            get { return !string.IsNullOrEmpty(Experience) && SelectedVenue != null; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewTravelVM()
        {
            Venues = new ObservableCollection<Result>();

            SaveCommand = new Command<bool>(Save,CanSave);
        }

        private void Save(bool parameter)
        {
            try
            {
                var firstCategory = SelectedVenue.categories.FirstOrDefault();
                Post post = new Post()
                {
                    Experience = Experience,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = SelectedVenue.location.address,
                    Distance = SelectedVenue.distance,
                    Latitude = SelectedVenue.geocodes.main.latitude,
                    Longitude = SelectedVenue.geocodes.main.longitude,
                    VenueName = SelectedVenue.name
                };

                bool result = Firestore.Insert(post);
                if (result)
                {
                    Experience = string.Empty;
                    App.Current.MainPage.DisplayAlert("Success", "Post saved", "Ok");
                }
                else
                    App.Current.MainPage.DisplayAlert("Failure", "Post was not saved, please try again", "Ok");

            }
            catch (NullReferenceException nre)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private bool CanSave(bool parameter)
        {
            return parameter;
        }

        public async void GetVenues(double lat, double lng)
        {
            var venues = await VenueLogic.GetVenues(lat, lng);

            Venues.Clear();
            foreach (var foo in venues)
            {
                Venues.Add(foo);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
