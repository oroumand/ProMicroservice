using Microsoft.AspNetCore.Mvc;
using NewCms.Core.Contracts.NewsAgg.Commands.CreateBlog;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsDetailes;
using NewCms.Core.Contracts.NewsAgg.Queries.NewsLists;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace NewCms.Endpoints.API.NewsAgg
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateNewsCommand createBlog)
        {
            return await Create(createBlog);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> Get([FromQuery] NewsList newsList)
        {
            return await Query<NewsList, PagedData<NewsListResult>>(newsList);
        }

        [HttpGet("GetDetail")]
        public async Task<IActionResult> Get([FromQuery] NewsDetaile newsDetaile)
        {
            return await Query<NewsDetaile, NewsDetaileResult>(newsDetaile);
        }
    }
}
