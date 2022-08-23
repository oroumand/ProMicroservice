using Microsoft.AspNetCore.Mvc;
using Zamin.EndPoints.Web.Controllers;
using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using BasicInfo.Core.Contracts.Keywords.Commands.InactiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Commands.ActiveKeywords;
using BasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.Contracts.Data.Queries;

namespace BasicInfo.Endpoints.API.Blogs
{
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateKeyword(CreateCategory createCategory)
        {
            return await Create<CreateCategory, long>(createCategory);
        }        
    }
}
