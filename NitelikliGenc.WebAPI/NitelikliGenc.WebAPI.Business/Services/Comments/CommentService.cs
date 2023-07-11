using NitelikliGenc.WebAPI.Business.Services.Concrete;
using NitelikliGenc.WebAPI.DataAccess.Repositories;
using NitelikliGenc.WebAPI.Entities.Entities;

namespace NitelikliGenc.WebAPI.Business.Services.Comments;

public class CommentService : BaseService<Comment>, ICommentService
{
    private readonly ICommentRepository _repository;
    
    public CommentService(ICommentRepository repository) : base(repository)
    {
        _repository = repository;
    }
}