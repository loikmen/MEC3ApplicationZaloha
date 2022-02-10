using Plugin.XamarinFormsSaveOpenPDFPackage;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MEC3AppSample;
using MEC3AppSample.Interfaces;
using MEC3AppSample.Model.Events;
using MEC3App.Views;
using MEC3App.ViewModel;

namespace MEC3AppSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private readonly IFilesService filesService;


        public ICommand DownloadPdfFileCommand { get; private set; }

        public ICommand OpenPdfFileCommand { get; private set; }
        


        public DetailsPage()
        {
            InitializeComponent();
            DownloadPdfFileCommand = new DelegateCommand(DownloadPdfFile);
            OpenPdfFileCommand = new DelegateCommand(OpenPdfFile);


            filesService = DependencyService.Get<IFilesService>();


            
        }

        async void returnHome(object sender, EventArgs e)
        {

            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(landingPage, true);

        }

        private void OpenPdfFile()
        {
            string pathToNewFolder = Path.Combine(filesService.StorageDirectory, "PdfFiles");
            string pathToNewFile = Path.Combine(pathToNewFolder, "https://foodsafety.wisc.edu/assets/icecream.pdf");
            filesService.OpenFile(pathToNewFile);
        }

        private void DownloadPdfFile()
        {
            
            filesService.OnFileDownloaded += FilesService_OnFileDownloaded;
            filesService.DownloadFile("https://foodsafety.wisc.edu/assets/icecream.pdf", "PdfFiles");

        }

        private void FilesService_OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            
        }

 
        async void Button_Clicked(Object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
           // var pdfUrl = neco;
            var stream = await httpClient.GetStreamAsync("https://foodsafety.wisc.edu/assets/icecream.pdf");

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);

                await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("File.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
            }  

        }

        protected override bool OnBackButtonPressed()
        {
            if (App.pageMonitor == 100)
            {

                var newViewModel = new CategoryViewModel(100, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 200) {

                var newViewModel = new CategoryViewModel(200, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);
                
            }

            if (App.pageMonitor == 400)
            {

                var newViewModel = new CategoryViewModel(400, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 600)
            {

                var newViewModel = new CategoryViewModel(600, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 700)
            {

                var newViewModel = new CategoryViewModel(700, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 800)
            {

                var newViewModel = new CategoryViewModel(800, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            return true;
        }








    }
}