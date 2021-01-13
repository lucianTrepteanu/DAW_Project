using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.Application.Data;
using Shop.Application.ProductsAdmin;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopUI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class ProductsController : Controller
    {
        private IConfiguration _configuration;
        private IUpload _uploadService;
        private ApplicationDbContext _ctx;

        public ProductsController(ApplicationDbContext ctx, IConfiguration configuration)
        {
            _configuration = configuration;
            _uploadService = new UploadService();
            //_uploadService = uploadService;
            _ctx = ctx;
        }

        [HttpGet("")]
        public IActionResult GetProducts() => Ok(new GetProducts(_ctx).Do());

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_ctx).Do(id));

        [HttpPost("")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) => Ok((await new CreateProduct(_ctx).Do(request)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok((await new DeleteProduct(_ctx).Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) => Ok((await new UpdateProduct(_ctx).Do(request)));

        [Route("[controller]/UploadProductImage/{id}")]
        public async Task<IActionResult> UploadProductImage(int id, IFormFile file)
        {
            var connectionString = _configuration.GetConnectionString("AzureStorageAccount");
            var container = _uploadService.GetBlobContainer(connectionString, "product-images");

            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var filename = parsedContentDisposition.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(filename);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            
            var product = _ctx.Products.FirstOrDefault(x => x.Id == id);
            product.ImageURL = blockBlob.Uri.AbsoluteUri;

            await _ctx.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
