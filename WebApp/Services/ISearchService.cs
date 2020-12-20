using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public interface ISearchService
    {
        List<Product> GetAllProductsByName(string query);
        Product GetProductById(int id);
        List<Product> GetAll();
    }
}