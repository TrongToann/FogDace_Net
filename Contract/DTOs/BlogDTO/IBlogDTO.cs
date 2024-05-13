namespace Contract.DTOs.BlogDTO
{
    public interface IBlogDTO
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int View { get; set; }
    }
}
