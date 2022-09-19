using BasicInfo.Core.Domain.Common.ValueObjects;
using BasicInfo.Core.Domain.Keywords.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace BasicInfo.Infra.Data.Sql.Commands.Common
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {

        }
    }

    public class TinyStringValueConversion : ValueConverter<TinyString, string>
    {
        public TinyStringValueConversion() : base(c => c.Value, c => TinyString.FromString(c))
        {

        }
    }
}
