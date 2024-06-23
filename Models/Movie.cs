using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPloomes.Models
{
    public class Movie {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        public int DirectorId { get; set; }
        public Director IdDirectorNavigation { get; set; }
    }
}
