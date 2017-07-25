using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internationalization.Data;
using Internationalization.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Internationalization.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<CurrencySettings> _currencySettings;

        public ProductService(ApplicationDbContext context, IOptions<CurrencySettings> currencySettings)
        {
            _context = context;
            _currencySettings = currencySettings;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context
                .FindAsync<Product>(id);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            return await _context
                .Products
                .Include(p => p.Currency)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Amount = GetAmount(p.Amount, p.Currency)
                })
                .ToListAsync();
        }

        public async Task<int> Add(Product product)
        {
            _context.Add(product);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> Update(Product product)
        {
            _context.Update(product);
            return await _context.SaveChangesAsync();
        }

        private double GetAmount(double amount, Currency currency)
        {
            if (currency.Symbol == "USD")
                return amount;
            var rate = _currencySettings.Value;
            return Math.Round(amount / rate.CNY, 2);
        }
    }
}