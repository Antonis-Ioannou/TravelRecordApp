using System;
using System.Collections.Generic;
using System.Text;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel
{
    public class PostDetailsVM
    {
        public Command UpdateCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Post SelectedPost { get; set; }

        public PostDetailsVM()
        {
            UpdateCommand = new Command<string>(Update, CanUpdate);
            DeleteCommand = new Command(Delete);
        }

        private async void Update(string foo)
        {
            SelectedPost.Experience = foo;

            bool result = await Firestore.Update(SelectedPost);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
        }

        private bool CanUpdate(string boo)
        {
            if (string.IsNullOrWhiteSpace(boo))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void Delete()
        {
            bool result = await Firestore.Delete(SelectedPost);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
