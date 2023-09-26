namespace ServicePost.Model.Dto
{
    public class UpdatePost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
