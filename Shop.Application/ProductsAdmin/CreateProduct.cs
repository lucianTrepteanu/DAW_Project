﻿using Microsoft.AspNetCore.Http;
using Shop.Application.Data;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;
        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
