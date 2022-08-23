using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Events;

namespace BasicInfo.Core.Domain.Categories.Events;
public class CategoryCreated: IDomainEvent
{
    public Guid BusinessId { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }

    public CategoryCreated(Guid businessId, string title,string name)
    {
        BusinessId = businessId;
        Title = title;
        Name = name;
    }
}
