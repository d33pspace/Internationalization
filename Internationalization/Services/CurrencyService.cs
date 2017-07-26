using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internationalization.Data;
using Internationalization.Models;
using Microsoft.EntityFrameworkCore;

namespace Internationalization.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDbContext _context;

        public CurrencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Currency> GetAsync(int id)
        {
            return await _context
                .FindAsync<Currency>(id);
        }

        public async Task<Currency> GetBySymbolAsync(string symbol)
        {
            return await _context
                .Currencies
                .FirstOrDefaultAsync(c => c.Symbol == symbol);
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context
                .Currencies
                .ToListAsync();
        }

        public string GetCurrentCurrency()
        {
            return null;
        }
    }
}
