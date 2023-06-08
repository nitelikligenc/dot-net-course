using Microsoft.AspNetCore.Mvc;
using NitelikliGenc.DatabasePoC.Database.Database;

namespace NitelikliGenc.DatabasePoC.Database.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly DataContext _dataContext;
    public BooksController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _dataContext.Books.ToList();

        return Ok(books);
    }

    [HttpGet("{bookId}/Book")]
    public IActionResult GetByBookId(int bookId)
    {
        var book = _dataContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
    
    [HttpGet("{authorId}/Author")]
    public IActionResult GetByAuthorId(int authorId)
    {
        var author = _dataContext.Authors.Where(b => b.Id == authorId).FirstOrDefault();
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }
}