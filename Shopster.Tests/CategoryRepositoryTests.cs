using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopster.DAL;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
using Shopster.DTOs;

namespace Shopster.Tests
{
    public class CategoryRepositoryFixture
    {
        public readonly AppDbContextFixture DbContextFixture;   

        public readonly CategoryRepository Repository;

        public CategoryRepositoryFixture() 
        {
            DbContextFixture = new AppDbContextFixture();
            Repository = new CategoryRepository(DbContextFixture.CreateAppDbContext());

            //private readonly IRepository<CategoryEntity> _categoryRepository;
        }
    }

    public class AppDbContextFixture
    {
        public AppDbContext CreateAppDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString: "Server=(localdb)\\mssqllocaldb;Database=ShopsterDB;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
            return new AppDbContext(optionsBuilder.Options);
        }
    }


    public class CategoryRepositoryTests
    {
        private readonly CategoryRepositoryFixture repositoryFixture;

        public CategoryRepositoryTests() 
        {
            repositoryFixture = new CategoryRepositoryFixture();
        }

        [Fact]
        public void Create_Should_Create_Category_In_DB()
        {
            //arrange
            var repository = repositoryFixture.Repository;
            //var category = _mapper.Map<CategoryEntity>(categoryDTO);
            //jak vytvorit umele kategorii??

            //act
            //repository.Create(category);



            //assert
            //List<Category> categories;
            //using (var appDbContext = repositoryFixture.DbContextFixture.CreateAppDbContext())
            //{
            //    categories = appDbContext.Category.ToList();
            //}


            var appDbContext = repositoryFixture.DbContextFixture.CreateAppDbContext();    
            var categories = appDbContext.Category.ToList();
            Debug.WriteLine(message: "categories");
            Debug.WriteLine(message: categories.ToString());

            Assert.Equal(5, categories.Count);

            //Assert.Single(categories);


        }

    }
}
