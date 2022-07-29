using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ProfileVM profileVM;

        public ProfilePage()
        {
            InitializeComponent();
            profileVM = Resources["foo"] as ProfileVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            profileVM.GetPosts();
        }
    }
}