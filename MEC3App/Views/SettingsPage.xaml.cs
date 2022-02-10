using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MEC3AppSample.Model;
using MEC3AppSample.ViewModel;
using System.ComponentModel;

namespace MEC3AppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        public BaseViewModel baseViewModel = new BaseViewModel();

        public string DisplayedImagePath
        {
            get { return @"https://www.eiskon.cz/data/katalog/manufacturer/10-mec3_logo_thumb.png"; }
        }

        public SettingsPage()
        {
            InitializeComponent();



        }

        async void returnHome(object sender, EventArgs e)
        {


            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(landingPage, true);






        }



    }
}