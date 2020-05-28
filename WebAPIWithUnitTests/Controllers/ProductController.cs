using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIWithUnitTests.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductServices _productService;

        public ProductController()
        {
            _productService = new ProductServices();
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET: api/Product/5
        public IHttpActionResult Get(int id)
        {
            var product = _productService.GetProductById(id);
            if(product!=null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest("No Data Found");
            }
        }

        // POST: api/Product
        public int Post([FromBody]ProductEntity productEntity)
        {
            return _productService.CreateProduct(productEntity);

        }

        // PUT: api/Product/5
        public bool Put(int id, [FromBody]ProductEntity productEntity)
        {
            if (id > 0)
            {
                return _productService.UpdateProduct(id, productEntity);
            }
            return false;
        }

        // DELETE: api/Product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _productService.DeleteProduct(id);
            return false;
        }
    }
}
