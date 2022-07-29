using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        private Post _selectedPost;

        public Post selectedPost 
        { 
            get { return _selectedPost; }
            set 
            {
                _selectedPost = value;
                if (_selectedPost != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new PostDetailPage(selectedPost));
                }
            }
        }

        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void GetPosts()
        {
            Posts.Clear();
            var posts = await Firestore.Read();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }
        }
    }
}
