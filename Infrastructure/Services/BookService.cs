namespace Infrastructure.Services;
using Dapper;
using DataContex;
using Domain.Models;

public class BookService
{
    private readonly DapperContext _context;
    public BookService()
    {
        _context = new DapperContext();
    }

    public void AddBook(Books books)
    {
        var sql = "insert into books (name,description,pages,anactive) values (@name,@description,@pages,@anactive)";
        _context.Connection().Execute(sql, books);
    }

    public void UpdateBook(Books books)
    {
        var sql = "update books set name = @name,description = @description,pages = @pages,anactive = @anactive where id = @id";
        _context.Connection().Execute(sql, books);
    }

    public void DeleteBook(int id)
    {
        var sql = "delete from books where id = @id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public List<Books> GetBooks()
    {
        var sql = "select * from books";
        var result = _context.Connection().Query<Books>(sql).ToList();
        return result;
    }

    public List<Books> GetBooksByAuthor(int id)
    {
        var sql = @"select b.Id,b.Name,b.Description,a.AuthorId,a.Fullname 
                    from AuthorBooks as ab 
                    join Books as b on ab.BookId = b.Id 
                    join Author as a on ab.AuthorId = a.AuthorId where a.AuthorId = @id";
        var result = _context.Connection().Query<Books>(sql).ToList();
        return result;
    }

    public List<Books> GetBooksByGenre(int id)
    {
        var sql = @"select b.Id,b.Name,b.Description,g.GenreId,g.GenreName
                    from GenreBook as gb
                    join Books as b on gb.BookId = b.Id
                    join Genre as g on gb.GenreId = g.GenreId where genreid = @id";
        var result = _context.Connection().Query<Books>(sql).ToList();
        return result;
    }


}


