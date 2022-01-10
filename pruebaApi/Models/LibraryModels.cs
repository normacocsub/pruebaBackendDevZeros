using Entity;
using System;


namespace PruebaApi.Models
{
    public class LibraryInputModels
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public LibraryInputModels()
        {
            Title = "";
            Author = "";
            Publisher = "";
            Genre = "";
            Price = 0;
        }
    }

    public class LibraryOutputModels : LibraryInputModels
    {
        public int Id { get; set; }
    }
}
