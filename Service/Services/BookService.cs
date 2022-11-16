using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.DTOs.Book;

using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Createasync(BookCreateDto book)
        {
            var mappedData = _mapper.Map<Book>(book);

            await _repo.Create(mappedData);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repo.Get(id);
            await _repo.Delete(book);
        }

        public async Task<List<BookListDto>> GetAllAsync()
        {

            return _mapper.Map<List<BookListDto>>(await _repo.GetAll());
        }

        public async Task SoftDeleteAsync(int id)
        {
            Book book = await _repo.Get(id);
            await _repo.SoftDelete(book);
        }

        public async Task UpdateAsync(int id, BookUpdateDto book)
        {
            var Dbbook = await _repo.Get(id);

            _mapper.Map(book, Dbbook);

            await _repo.Update(Dbbook);
        }

        public async Task<List<BookListDto>> SearchAsync(string? searchText)
        {
            List<Book> searchDatas = new();

            if (searchText != null)
            {
                searchDatas = await _repo.FindAllByExpressionAsync(m => m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repo.GetAll();
            }

            return _mapper.Map<List<BookListDto>>(searchDatas);
        }

        public async Task<Book> GetById(int id)
        {
            return await _repo.Get(id);
        }
    }
}
