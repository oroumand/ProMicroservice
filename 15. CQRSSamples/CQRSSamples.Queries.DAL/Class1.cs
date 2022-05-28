using CQRSSamples.Framework;
using Microsoft.EntityFrameworkCore;

namespace CQRSSamples.Queries.DAL;
public class RepSampleQueryDbContext : BaseQueryDbContext
{
    public RepSampleQueryDbContext(DbContextOptions options) : base(options)
    {
    }
}