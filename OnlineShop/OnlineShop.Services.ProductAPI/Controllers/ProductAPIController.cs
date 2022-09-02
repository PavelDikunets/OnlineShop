using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductAPI.Models.Dtos;
using OnlineShop.Services.ProductAPI.Repository;

namespace OnlineShop.Services.ProductAPI.Controllers
{
    [Route("/api/prioducts")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto response;
        private IProductRepository productRepository;
        public ProductAPIController(IProductRepository _productRepository)
        {
            this.response = new ResponseDto();
            productRepository = _productRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productsDto = await productRepository.GetProducts();
                response.Result = productsDto;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(Guid id)
        {
            try
            {
                ProductDto productDto = await productRepository.GetProductById(id);
                response.Result = productDto;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await productRepository.CreateUpdateProduct(productDto);
                response.Result = model;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await productRepository.CreateUpdateProduct(productDto);
                response.Result = model;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpDelete]
        public async Task<object> Delete(Guid id)
        {
            try
            {
                bool IsSuccess = await productRepository.DeleteProduct(id);
                response.Result = IsSuccess;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return response;
        }
    }
}

