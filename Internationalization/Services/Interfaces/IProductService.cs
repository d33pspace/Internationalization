using System.Collections.Generic;
using System.Threading.Tasks;
using Internationalization.Models;

namespace Internationalization.Services
{
    public interface IProductService
    {
        Task<Product> GetAsync(int id);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<int> Add(Product product);
        Task<int> Update(Product product);
    }
}