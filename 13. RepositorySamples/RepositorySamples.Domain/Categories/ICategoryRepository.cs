using RepositorySamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySamples.Domain.Categories;
public interface ICategoryRepository:IRepository<Category>
{
    public void Add(Category category);
}
