using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookservice;
    public BookController()
    {
        _bookservice = new BookService();
    }

    [HttpPost("Add Book")]
    public void AddBook(Books books)
    {
        _bookservice.AddBook(books);
    }

    [HttpGet("Get Books")]
    public List<Books> GetBooks()
    {
        return _bookservice.GetBooks();
    }
    
    [HttpPut("Update Book")]
    public void UpdateBook(Books books)
    {
        _bookservice.UpdateBook(books);
    }
 
    [HttpDelete("Delete Book")]
    public void DeleteBook(int id)
    {
        _bookservice.DeleteBook(id);
    }
    
    [HttpGet("Get Book By Author")]
    public List<Books> GetBooksByAuthor(int id)
    {
        return _bookservice.GetBooksByAuthor(id);
    }
    
    [HttpGet("Get Book By Genre")]
    public List<Books> GetBooksByGenre(int id)
    {
        return _bookservice.GetBooksByGenre(id);
    }

}


