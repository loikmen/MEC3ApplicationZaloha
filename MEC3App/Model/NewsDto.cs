using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class NewsDto
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Image { get; set; }
        public string Perex { get; set; }
        public string Content { get; set; }

        public NewsDto(string name, int iD, string image, string perex, string content)
        {
            Name = name;
            ID = iD;
            Image = image;
            Perex = perex;
            Content = content;
        }
    }
}
