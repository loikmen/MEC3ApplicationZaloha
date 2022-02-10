using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class NewsDetailApiModel
    {

        public class Rootobject
        {
            public Data Data { get; set; }
        }

        public class Data
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Image { get; set; }
            public string Perex { get; set; }
            public string Content { get; set; }
        }

    }
}
