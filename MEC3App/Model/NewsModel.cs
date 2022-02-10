using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model.Events
{
    public class NewsModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public string Perex { get; set; }
        public object Content { get; set; }


        public NewsModel(string name, string image, int id, string perex, object content)
        {
            Name = name;
            Image = image;
            Id = id;
            Perex = perex;
            Content = content;
        }
    }
}
