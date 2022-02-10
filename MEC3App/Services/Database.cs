using MEC3App.Model;
using MEC3AppSample.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MEC3AppSample.Services
{
    public class Database
    {

        public SQLiteAsyncConnection _database;


        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CategoryDto>();
            _database.CreateTableAsync<DetailDto>();
        }

         public Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return _database.Table<CategoryDto>().ToListAsync();
        }

        public Task<int> SaveCategoryItemAsync(CategoryDto categoryDto)
        {
            return _database.InsertAsync(categoryDto);
        }

        public Task<int> DeleteCategoryItemAsync(CategoryDto categoryDto)
        {

            return _database.DeleteAsync(categoryDto);
        }

        public Task<List<DetailDto>> GetDetailsAsync()
        {
            return _database.Table<DetailDto>().ToListAsync();
        }

        public Task<int> SaveDetailItemAsync(DetailDto detailDto)
        {
            return _database.InsertAsync(detailDto);
        }

        public Task<int> DeleteDetailItemAsync(DetailDto detailDto)
        {

            return _database.DeleteAsync(detailDto);
        }

    




    }
}
