using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Library : EntityClass<Library>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        public Library()
        {
            Title = "";
            Author = "";
            Publisher = "";
            Genre = "";
            Price = 0;
        }
    }
}