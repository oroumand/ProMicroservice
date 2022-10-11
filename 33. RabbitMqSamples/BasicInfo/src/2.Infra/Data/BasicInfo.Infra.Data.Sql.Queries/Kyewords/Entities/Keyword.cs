using BasicInfo.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInfo.Infra.Data.Sql.Queries.Kyewords.Entities;

public class Keyword
{
    public long Id { get; set; }
    public Guid BusinessId { get; set; }
    public KeywordStatus Status { get; set; }
    public string Title { get; set; }
}