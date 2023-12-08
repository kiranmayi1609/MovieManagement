namespace WebAPI.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieActor> MovieActor { get; set; }
    }
}
