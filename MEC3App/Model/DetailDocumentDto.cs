using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class DetailDocumentDto
    {

        public string Name { get; set; }
        public string Url { get; set; }

        public DetailDocumentDto(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
