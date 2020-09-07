namespace Kickoff.Models.Shared
{
    public class NavigationItemModel
    {
        public NavigationItemModel()
        {
        }

        public NavigationItemModel(int id, string title, string url)
        {
            Id = id;
            Title = title;
            Url = url;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsCurrentPage { get; set; }
    }
}