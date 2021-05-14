using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericBaseController<Product, IProductService>
    {
        public ProductsController(IProductService productService) : base(productService)
        {
        }

        [HttpGet("getall")]
        //[Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
            return base.GetResponseByResultSuccess(base._service.GetList());
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            return base.GetResponseByResultSuccess(base._service.GetListByCategory(categoryId));
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(productId));
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            return base.GetResponseByResultSuccess(base._service.TransactionalOperation(product));
        }

    }
}