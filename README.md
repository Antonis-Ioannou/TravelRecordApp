# TravelRecordApp
A Xamarin.Forms - Firebase Cloud - MVVM - GoogleMaps app

![History_page](https://user-images.githubusercontent.com/91195165/181703478-a1e4bc1f-f568-4871-9432-dd42171376cc.png)
![FourSquare_Api-Call](https://user-images.githubusercontent.com/91195165/181703514-e302dd09-305a-42fa-8c03-227adf556239.png)
![Map_page](https://user-images.githubusercontent.com/91195165/181703530-9612457c-a23f-4fdf-af0e-d81da1dc5e3d.png)
![Profile_page](https://user-images.githubusercontent.com/91195165/181703539-79375326-b5c2-4489-82c4-85fa5d2d4fc2.png)

An Android mobile app for writing notes/reviews of the places you visited!
Using your phone's location, the app uses FourSquare's api to track all available nearby venues which are then 
displayed in a list. Just Highlight the venue and write your experience. Once you save the changes, a pin is created on the 
map right at the venues location as a well a generic description of the venue at the profile page.

What you need to do:
1) Set up your own Firestore cloud database and authentication.
2) Create your own FourSquare api credentials and paste them in the Constant.cs class located in the Helpers file of the common project. 
3) Create your own Google maps api and paste the key in the Android Manifest xml.
