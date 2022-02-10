using MEC3App.Model;
using MEC3App.Model.Events;
using MEC3App.Views;
using MEC3AppSample.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MEC3App.ViewModel
{
    class NewsViewModel : BaseViewModel
    {

        public NewsViewModel()
        {
            newsCards = GetNewsList();

        }

        ObservableCollection<NewsModel> newsCards;
        public ObservableCollection<NewsModel> NewsCards
        {
            get { return newsCards; }
            set
            {
                newsCards = value;
                OnPropertyChanged();
            }
        }

        private NewsModel selectedCard;
        public NewsModel SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged();
            }
        }

        private int position;
        public int Position
        {


            get
            {
                if (position != newsCards.IndexOf(selectedCard))
                    return newsCards.IndexOf(selectedCard);

                return position;
            }
            set
            {
                position = value;
                selectedCard = newsCards[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedCard));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = newsCards.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == newsCards.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }
        }


        private Command selectionCommand;

        public ICommand SelectionCommand
        {
            get
            {
                if (selectionCommand == null)
                {
                    selectionCommand = new Command(DisplayNewsDetail);
                }

                return selectionCommand;
            }
        }

        private void DisplayNewsDetail()
        {

            var newViewModel = new NewsDetailViewModel(selectedCard.Id) {};
            var newPage = new NewsDetailPage { BindingContext = newViewModel };
            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(newPage, true);
        }

        public NewsApiModel.Rootobject GetNewsApiModel()
        {

            var NewsApiModel = new NewsApiModel.Rootobject();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var requestObj = (HttpWebRequest)WebRequest.Create("https://mec3.cz/mec3mobile/DocumentsMobile/GetNews"); ;
            requestObj.Method = "Get";

            var responseObj = (HttpWebResponse)requestObj.GetResponse();
            if (responseObj.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    NewsApiModel = JsonConvert.DeserializeObject<NewsApiModel.Rootobject>(sr.ReadToEnd());
                    sr.Close();
                }
            }
            return NewsApiModel;
        }

        public ObservableCollection<NewsModel> GetNewsList()
        {
            var NewsList = new ObservableCollection<NewsModel>();
            var model = GetNewsApiModel();

            foreach (var result in model.Data)
            {
                var name = result.Name;
                var image = result.Image;
                var id = result.ID; ;
                var description = result.Perex;
                var content = result.Content;

                NewsList.Add(new NewsModel(name, image, id, description, content));
            }

            return NewsList;
        }


    }

}

