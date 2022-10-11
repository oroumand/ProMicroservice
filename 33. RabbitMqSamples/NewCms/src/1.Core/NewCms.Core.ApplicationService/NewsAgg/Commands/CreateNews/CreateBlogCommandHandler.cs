using NewCms.Core.Contracts.NewsAgg.Commands.CreateBlog;
using NewCms.Core.Contracts.NewsAgg.DAL;
using NewCms.Core.Domain.NewsAgg.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Utilities;

namespace NewCms.Core.ApplicationService.NewsAgg.Commands.CreateNews
{
    public class CreateBlogCommandHandler : CommandHandler<CreateNewsCommand>
    {

        private readonly INewsCommandRepository _blogCommandRepository;

        public CreateBlogCommandHandler(ZaminServices zaminServices, INewsCommandRepository blogCommandRepository) : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult> Handle(CreateNewsCommand request)
        {
            News blog = new(request.BusunessId, request.Title, request.Description, request.Body,
                request.KeywordsId.Select(c => new NewsKeyword
                {
                    KeywordBusinessId = BusinessId.FromGuid(c)
                }).ToList());
            _blogCommandRepository.Insert(blog);
            try
            {
                await _blogCommandRepository.CommitAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return await OkAsync();

        }
    }
}
