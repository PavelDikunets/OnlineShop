using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.ProductAPI.DbContexts;
using OnlineShop.Services.ProductAPI.Models;
using OnlineShop.Services.ProductAPI.Models.Dtos;

namespace OnlineShop.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        private IMapper mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = mapper.Map<ProductDto, Product>(productDto);
            if (product.Name != null)
            {
                db.Products.Update(product);
            }
            else
            {
                db.Products.Add(product);
            }
            await db.SaveChangesAsync();
            return mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            try
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                {
                    return false;
                }
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ProductDto> GetProductById(Guid productId)
        {
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await db.Products.ToListAsync();
            return mapper.Map<List<ProductDto>>(productList);
        }
    }
}
