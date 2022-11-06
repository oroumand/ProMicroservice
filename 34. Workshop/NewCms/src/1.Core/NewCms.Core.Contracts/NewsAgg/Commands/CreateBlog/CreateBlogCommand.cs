using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewCms.Core.Contracts.NewsAgg.Commands.CreateBlog
{
    public class CreateNewsCommand : ICommand
    {
        public Guid BusunessId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<Guid> KeywordsId { get; set; }
    }
}
