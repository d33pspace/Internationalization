using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internationalization.Models;
using Internationalization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internationalization.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICurrencyService _currencyService;

        public ProductsController(IProductService productService, ICurrencyService currencyService)
        {
            _productService = productService;
            _currencyService = currencyService;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }


        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            var currencies = await _currencyService.GetAllAsync();
            var product = new ProductViewModel
            {
                CurrencyList = new List<SelectListItem>(currencies.Select(c =>
                    new SelectListItem
                    {
                        Text = c.Symbol,
                        Value = c.Id.ToString()
                    }))
            };
            return View(product);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _productService.Add(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var currencies = await _currencyService.GetAllAsync();
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CurrencyId = product.CurrencyId,
                Amount = product.Amount,
                CurrencyList = new List<SelectListItem>(currencies.Select(c =>
                    new SelectListItem
                    {
                        Text = c.Symbol,
                        Value = c.Id.ToString()
                    }))
            };
            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Update(product);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                //await _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}