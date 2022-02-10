using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static MEC3App.Model.DetailApiModel;

namespace MEC3App.Model
{
    public class DetailProductDto
    {
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ObservableCollection<DetailDocumentDto> Documents { get; set; }

        public DetailProductDto(string name, string partNumber, int iD, string description, string image, ObservableCollection<DetailDocumentDto> documents)
        {
            Name = name;
            PartNumber = partNumber;
            ID = iD;
            Description = description;
            Image = image;
            Documents = documents;
        }
    }
}
