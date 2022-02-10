using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3App.Model
{
    public class CategoryDto
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int BaseIndex { get; set; }


        public CategoryDto()
        {

        }
        
        public CategoryDto(string name, string image, int baseIndex)
        {
            Name = name;
            Image = image;
            BaseIndex = baseIndex;

        }     
    }
}

