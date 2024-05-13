namespace Contract.DTOs.BlogDTO
{
    public class CreateBlogDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public ICollection<InputContent> Contents { get; set; }
    }
    public class InputContent()
    {
        public string Title { get; set; }
        public string Script { get; set; }
        public string Image { get; set; }
    }
}
