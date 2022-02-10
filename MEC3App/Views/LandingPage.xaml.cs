using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MEC3AppSample;
using System.ComponentModel;
using MEC3AppSample.Model;
using MEC3AppSample.ViewModel;
using MEC3AppSample.Views;
using System.Collections.ObjectModel;
using MEC3App.Views;
using MEC3App.ViewModel;

namespace MEC3AppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {

        public LandingViewModel landingViewModel = new LandingViewModel();
        private CategoryViewModel categoryViewModel = new CategoryViewModel();

        public LandingPage()
        {
            InitializeComponent();

        }

        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetBaseItemsAsync();
        }

        async void AddBaseItemToDB(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SaveBaseItemAsync(new BaseModel
                {
                    
                    Name = nameEntry.Text,
                    Image = "https://berryworld.imgix.net/assets/Strawberry-Easy-Ice-Cream-Overhead-SQ.jpg?crop=focalpoint&fit=crop&fp-x=0.5&fp-y=0.5&h=1500&q=60&w=2300",
                    Description = "Luxusní zmrzlina podle tradiční receptury.",
                    Price = 99


                });
                  
                nameEntry.Text = string.Empty;

                collectionView.ItemsSource = await App.Database.GetBaseItemsAsync();

                landingViewModel.BaseCardsRefresh();
            }
        }

       
        async void DeleteBaseModel(object sender, EventArgs e)
        {           
            await App.Database.DeleteBaseItemAsync(landingViewModel.baseCards[landingViewModel.baseCards.Count-1]);
            landingViewModel.baseCards.Remove(landingViewModel.baseCards[landingViewModel.baseCards.Count-1]);

            collectionView.ItemsSource = await App.Database.GetBaseItemsAsync();
            
        }
        */


            async void OnButtonClickedLogin(object sender, EventArgs e)
        {

            var loginPage = new Page1();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(loginPage, true);
        }

        async void OnButtonClickedSeminars(object sender, EventArgs e)
        {

            var seminarsPage = new SeminarListPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(seminarsPage, true);
        }

        async void OnButtonClickedSettings(object sender, EventArgs e)
        {

            var settingsPage = new SettingsPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(settingsPage, true);
        }

        async void OnButtonClickedNews(object sender, EventArgs e)
        {
            var newsPage = new NewsPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(newsPage, true);
        }

        protected override bool OnBackButtonPressed()
        {


            return true;
        }

    }
}
