using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BL;

namespace Project1.WebUI
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        [HttpGet("api/product/{id}")]
        public BL.Product GetProductById(int id) 
        {
            return _productRepository.GetProductById(id);
        }
    }
}