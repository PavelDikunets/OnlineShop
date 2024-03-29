﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductAPI.Models.Dto;
using OnlineShop.Services.ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductAPI.Controllers
{
    [Route("/api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
