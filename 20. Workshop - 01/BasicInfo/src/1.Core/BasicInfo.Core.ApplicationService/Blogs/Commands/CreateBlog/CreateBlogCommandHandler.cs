using BasicInfo.Core.Contracts.Blogs.CommandRepositories;
using BasicInfo.Core.Contracts.Blogs.Commands.CreateBlog;
using BasicInfo.Core.Domain.Blogs.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace BasicInfo.Core.ApplicationService.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : CommandHandler<CreateBlogCommand>
    {

        private readonly IBlogCommandRepository _blogCommandRepository;

        public CreateBlogCommandHandler(ZaminServices zaminServices, IBlogCommandRepository blogCommandRepository) : base(zaminServices)
        {
            _blogCommandRepository = blogCommandRepository;
        }

        public override async Task<CommandResult> Handle(CreateBlogCommand request)
        {
            Blog blog = new(request.BusunessId, request.Title, request.Description);
            _blogCommandRepository.Insert(blog);
            await _blogCommandRepository.CommitAsync();
            return await OkAsync();
        }
    }
}
