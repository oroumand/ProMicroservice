using Zamin.Core.Domain.Events;

namespace BasicInfo.Core.Domain.Keywords.Events;

public class KeywordActivated : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public KeywordActivated(Guid businessId)
    {
        BusinessId = businessId;

    }
}
