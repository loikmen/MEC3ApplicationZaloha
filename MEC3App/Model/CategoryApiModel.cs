using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class CategoryApiModel
    {
        public class Rootobject
        {
            public Data Data { get; set; }
        }

        public class Data
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public Subcategory[] SubCategories { get; set; }
        }

        public class Subcategory
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Image { get; set; }
        }
    }
}
