
using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReviewById(int id);

        ICollection<Review> GetReviewsOfAnime(int animeId);

        bool ReviewExists(int id);
    }
}
