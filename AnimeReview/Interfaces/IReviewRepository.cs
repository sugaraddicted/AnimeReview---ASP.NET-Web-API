
using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReviewById(int id);

        ICollection<Review> GetReviewsOfAnime(int animeId);

        ICollection<Review> GetReviewsOfReviewer(int reviewerId);

        bool ReviewExists(int id);

        bool CreateReview(Review review);

        bool UpdateReview(Review review);

        bool DeleteReviews(List<Review> reviews);  

        bool DeleteReview(Review review);  

        bool Save();
    }
}
