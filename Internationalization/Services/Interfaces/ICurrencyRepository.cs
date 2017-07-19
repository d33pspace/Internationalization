﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Internationalization.Models;

namespace Internationalization.Services
{
    public interface ICurrencyRepository
    {
        Task<Currency> GetAsync(int id);
        Task<Currency> GetBySymbolAsync(string symbol);
        Task<List<Currency>> GetAllAsync();
    }
}