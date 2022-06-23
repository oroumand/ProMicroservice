using BasicInfo.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace BasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;

public class TitleAndStatus:PageQuery<PagedData<KeywordSearchResult>>
{
    public string Title { get; set; }
    public KeywordStatus? Status { get; set; }

}

public class KeywordSearchResult
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public KeywordStatus Status { get; set; }
    public string Title { get; set; }
}