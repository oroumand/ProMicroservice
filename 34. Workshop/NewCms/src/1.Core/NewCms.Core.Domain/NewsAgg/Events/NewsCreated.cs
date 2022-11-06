using Zamin.Core.Domain.Events;

namespace NewCms.Core.Domain.NewsAgg.Events
{
    public class NewsCreated : IDomainEvent
    {
        public string BusinessId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Body { get; private set; }
        public string Keyword { get; private set; }
        public NewsCreated(string businessId, string title, string description, string body, string keywords)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
            Body = body;
            Keyword = keywords;
        }
    }
}
