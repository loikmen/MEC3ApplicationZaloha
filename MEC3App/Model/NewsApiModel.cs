using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    class NewsApiModel
    {

        public class Rootobject
        {
            public Datum[] Data { get; set; }
        }

        public class Datum
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Image { get; set; }
            public string Perex { get; set; }
            public object Content { get; set; }
        }


    }
}
