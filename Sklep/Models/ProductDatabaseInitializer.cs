using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sklep.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Warzywa"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Owoce"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Nabiał"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Mięso"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Pieczywo"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Jabłka grójeckie",
                    Description = "opis jabłka",
                    ImagePath = "apple.png",
                    UnitPrice = 4.50,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Cukinia",
                    Description = "opis cukinii",
                    ImagePath = "zuchcini.png",
                    UnitPrice = 6.50,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Ser parmezan",
                    Description = "opis sera",
                    ImagePath = "parmezan.png",
                    UnitPrice = 85.50,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Ser mozarella",
                    Description = "opis sera",
                    ImagePath = "mozarella.png",
                    UnitPrice = 26.50,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Mięso mielone wołowe",
                    Description = "opis mięsa",
                    ImagePath = "mincemeat.png",
                    UnitPrice = 16.50,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Filet z indyka",
                    Description = "opis mięsa",
                    ImagePath = "turkeyfillet.png",
                    UnitPrice = 22.50,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Marchewka",
                    Description = "opis marchewki",
                    ImagePath = "carrot.png",
                    UnitPrice = 3.50,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Bułka razowa",
                    Description = "opis bułki",
                    ImagePath = "wholewheatbun.png",
                    UnitPrice = 6.50,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Pomarańcze",
                    Description = "opis pomarańczy",
                    ImagePath = "zuchcini.png",
                    UnitPrice = 5.50,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Chleb orkiszowy",
                    Description = "opis cukinii",
                    ImagePath = "speltbread.png",
                    UnitPrice = 16.50,
                    CategoryID = 1
                },
            };
            return products;
        }
    }
}