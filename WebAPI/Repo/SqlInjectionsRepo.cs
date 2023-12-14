using Microsoft.Data.SqlClient;
using WebAPI.Interfaces.Non_Generic;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class SqlInjectionsRepo : IReview
    {
        public void AddReview(IReview review)
        {
            throw new NotImplementedException();
        }

        public void DeleteReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReview> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public IReview GetReviewById(int reviewId)
        {
            using (SqlConnection connection = new SqlConnection("connection "))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Reviews WHERE ReviewId = @ReviewId", connection))
                {
                    command.Parameters.AddWithValue("@ReviewId", reviewId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Review review = new Review
                            {
                                ReviewId = (int)reader["ReviewId"],
                                Comment = (string)reader["Comment"],
                                Rating = (int)reader["Rating"],
                                MoviesId = (int)reader["MoviesId"]
                            };

                            //  fetch the related Movies based on the MoviesId
                            review.Movies = GetMoviesById(review.MoviesId);

                            return (IReview)review;
                        }
                    }
                }
            }

            return null;
        }

        private Movies GetMoviesById(int moviesId)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(IReview review)
        {
            throw new NotImplementedException();
        }
    }

       
 }

