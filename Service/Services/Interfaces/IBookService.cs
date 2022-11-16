using Domain.Entities;
using Service.Services.DTOs.Book;
using Service.Services.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task Createasync(BookCreateDto book);
        Task<List<BookListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookUpdateDto product);
        Task<List<BookListDto>> SearchAsync(string? searchText);
        Task<Book> GetById(int id);
    }
}
