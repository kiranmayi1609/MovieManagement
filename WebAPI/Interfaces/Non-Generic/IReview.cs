namespace WebAPI.Interfaces.Non_Generic
{
    public interface IReview
    {
        IReview GetReviewById(int reviewId);
        IEnumerable<IReview> GetAllReviews();
        void AddReview(IReview review);
        void UpdateReview(IReview review);
        void DeleteReview(int reviewId);
    }
}
