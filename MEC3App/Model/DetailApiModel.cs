using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class DetailApiModel
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
            public string Description { get; set; }
            public Product[] Products { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string PartNumber { get; set; }
            public int ID { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public Document[] Documents { get; set; }
        }

        public class Document
        {
            public string Nazev { get; set; }
            public string Url { get; set; }
        }



    }
}
