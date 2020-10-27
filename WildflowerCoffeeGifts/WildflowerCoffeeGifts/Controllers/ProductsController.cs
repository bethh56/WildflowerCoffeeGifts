﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildflowerCoffeeGifts.DataAccess;
using WildflowerCoffeeGifts.Models;

namespace WildflowerCoffeeGifts.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsRepository _productsRepo;
        public ProductsController()
        {
            _productsRepo = new ProductsRepository();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productsRepo.GetProducts();

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public IActionResult ViewSingleProduct(int id)
        {
            var singleProduct = _productsRepo.ViewProductById(id);
            if (singleProduct == null) return NotFound("Nothing was found with this id! Try again.");

            return Ok(singleProduct);

        }

        [HttpPost]
        public IActionResult AddNewProduct(Product newItem)
        {
            var createNewProduct = _productsRepo.NewProduct(newItem);

            return Created($"/api/products/{newItem.Id}", createNewProduct);
        }
    }
}