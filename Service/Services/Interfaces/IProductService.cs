using Domain.Entities;
using Service.Services.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IProductService
    {
        Task Createasync(ProductCreateDto product);
        Task<List<ProductListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, ProductUpdateDto product);
        Task<List<ProductListDto>> SearchAsync(string? searchText);
        Task<Product> GetById(int id);
    }
}
