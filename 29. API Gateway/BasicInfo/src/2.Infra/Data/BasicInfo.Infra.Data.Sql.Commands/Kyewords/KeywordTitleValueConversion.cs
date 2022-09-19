using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasicInfo.Infra.Data.Sql.Commands.Kyewords;

public class KeywordTitleValueConversion : ValueConverter<KeywordTitle, string>
{
    public KeywordTitleValueConversion() : base(c => c.Value, c => KeywordTitle.FromString(c))
    {

    }
}