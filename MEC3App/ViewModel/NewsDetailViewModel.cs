using MEC3App.Model;
using MEC3App.Model.Events;
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
    class NewsDetailViewModel : BaseViewModel
    {


        public NewsDetailViewModel(int id)
        {
           newsCard =  GetDetailList(id);

        }

        private NewsDto newsCard;
        public NewsDto NewsCard
        {
            get { return newsCard; }
            set
            {
                newsCard = value;
                OnPropertyChanged();
            }
        }
    

        public NewsDetailApiModel.Rootobject GetNewsDetailModel(int id)
        {

            var NewsDetailModel = new NewsDetailApiModel.Rootobject();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var requestObj = (HttpWebRequest)WebRequest.Create("https://mec3.cz/mec3mobile/DocumentsMobile/GetNews/" + id); ;
            requestObj.Method = "Get";


            var responseObj = (HttpWebResponse)requestObj.GetResponse();
            if (responseObj.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    NewsDetailModel = JsonConvert.DeserializeObject<NewsDetailApiModel.Rootobject>(sr.ReadToEnd());
                    sr.Close();
                }
            }
            return NewsDetailModel;

        }

        public NewsDto GetDetailList(int index)
        {

            var model = GetNewsDetailModel(index);

            var name = model.Data.Name;
            var image = model.Data.Image;
            var id = model.Data.ID;
            var description = model.Data.Perex;
            var content = model.Data.Content;

            var NewsDto = new NewsDto(name, id, image, description, content);


            return NewsDto;
        }







    }
}
