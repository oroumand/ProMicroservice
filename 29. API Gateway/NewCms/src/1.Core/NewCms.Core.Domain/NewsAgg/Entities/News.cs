using NewCms.Core.Domain.NewsAgg.Events;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;

namespace NewCms.Core.Domain.NewsAgg.Entities
{
    public class News : AggregateRoot
    {
        #region Properties
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public string Body { get; set; }

        private readonly List<NewsKeyword> _newsKeywords = new List<NewsKeyword>();

        public IReadOnlyList<NewsKeyword> NewsKeywords => _newsKeywords;
        #endregion

        #region Constructors
        private News()
        {

        }
        public News(BusinessId businessId, Title title, Description description, string body, List<NewsKeyword> newsKeywords)
        {
            BusinessId = businessId;
            Title = title;
            Description = description;
            Body = body;
            _newsKeywords.AddRange(newsKeywords);
            AddEvent(new NewsCreated(businessId.Value.ToString(), Title.Value, Description.Value, body, string.Join(";", _newsKeywords.Select(c => c.KeywordBusinessId).ToList())));
        }
        #endregion

    }
}
