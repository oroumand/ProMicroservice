using Microsoft.AspNetCore.Mvc;
using BasicInfo.Core.Contracts.Blogs.Commands.CreateBlog;
using Zamin.EndPoints.Web.Controllers;

namespace BasicInfo.Endpoints.API.Blogs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogCommand createBlog )
        {
            return await Create(createBlog);
        }
    }
}
