namespace WebAPI.Dto
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }

        public int Rating { get; set; }

        public int MovieId { get; set; }

    }
}
