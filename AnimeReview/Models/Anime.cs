namespace AnimeReview.Models
{
    public class Anime
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; } 

        public DateTime ReleaseDate { get; set; }

        public Country Country { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<AnimeGenre> AnimeGenres { get; set; } 
    }
}
