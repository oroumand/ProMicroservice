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
    public class KeywordsController : BaseController
    {
        [HttpPost("CreateKeyword")]
        public async Task<IActionResult> CreateKeyword(CreateKeyword createKeyword)
        {
            return await Create<CreateKeyword, long>(createKeyword);
        }

        [HttpPost("ChangeTitle")]
        public async Task<IActionResult> ChangeTitle(ChangeTitle changeTitle)
        {
            return await Edit(changeTitle);
        }

        [HttpPost("Active")]
        public async Task<IActionResult> Active(ActiveKeyword changeTitle)
        {
            return await Edit(changeTitle);
        }

        [HttpPost("Inactive")]
        public async Task<IActionResult> Inactive(InactiveKeyword changeTitle)
        {
            return await Edit(changeTitle);
        }


        [HttpGet("SearchTitleAndStatus")]

        public async Task<IActionResult> SearchTitleAndStatus(TitleAndStatus titleAndStatus)
        {
            return await Query< TitleAndStatus, PagedData<KeywordSearchResult>>(titleAndStatus);
        }
    }
}
