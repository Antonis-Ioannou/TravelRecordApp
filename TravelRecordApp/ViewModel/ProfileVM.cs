using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.ViewModel
{
    public class ProfileVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CategoryCount> Categories { get; set; }

        private int postCount;

        public int PostCount 
        { 
            get { return postCount; } 
            set 
            {
                postCount = value;
                OnPropertyChanged("PostCount");
            } 
        }

        public ProfileVM()
        {
            Categories = new ObservableCollection<CategoryCount>();
        }

        public async void GetPosts()
        {
            Categories.Clear();
            var posts = await Firestore.Read();

            PostCount = posts.Count();

            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            foreach (var category in categories)
            {
                //var count = (from post in posts
                //             where post.CategoryName == category
                //             select post).ToList().Count();

                var count2 = posts.Where(p => p.CategoryName == category).ToList().Count();

                Categories.Add(new CategoryCount
                {
                    Name = category,
                    Count = count2
                });
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public class CategoryCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}