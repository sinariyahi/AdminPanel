using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using InfraStructure;
using InfraStructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductRepository : IBaseSevice, IProductRepository
    {
        private readonly IRepository<Product> _productRepository;
        protected readonly IMapper _mapper;

        public ProductRepository(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _productRepository.AddAsync(product, cancellationToken);
            return product;
        }
        public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateAsync(product, cancellationToken);
            return product;
        }
        public async Task<Product> FindProductAsync(int id, CancellationToken cancellationToken)
        {
            var cat = await _productRepository.GetByIdAsync(cancellationToken, id);
            return cat;
        }
        public async Task<PagedList<ProductGridView>> GetAll(int pageNumber, int pageSize, string name, CancellationToken cancellationToken)
        {
            var outPut = new PagedList<ProductGridView>();
            var t = _productRepository.TableNoTracking.Where(x => x.Name.Contains(name)).OrderByDescending(d => d.ID);
            outPut.TotalCount = await t.CountAsync();
            outPut.list = await t.Skip(pageNumber * pageSize).Take(pageSize).ProjectTo<ProductGridView>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return outPut;
        }
        //{
        /*
        private ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public Product GetProduct(long id)
        {
            return context.Products.Find(id);
        }

        public ICollection<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Producer GetProducerForProduct(long id)
        {
            return context.Producers.Find(
                context.Products.Find(id)?.ProducerID
            );
        }

        public Category GetCategoryForProduct(long id)
        {
            return context.Categories.Find(
                context.Products.Find(id)?.CategoryID
            );
        }

        public Subcategory GetSubcategoryForProduct(long id)
        {
            return context.Subcategories.Find(
                context.Products.Find(id)?.SubcategoryID
            );
        }

        public ICollection<Review> GetReviewsForProduct(long id)
        {
            return context.Reviews.Where(r => r.ProductID == id).ToList();
        }

        public ICollection<Discount> GetDiscountsForProduct(long id)
        {
            return context.Discounts.Where(d => d.ProductID == id).ToList();
        }

        public bool CheckIfProductIsAvailable(long id, int neededQuantity = 0)
        {
            return context.Products.Find(id).AvailableQuantity > neededQuantity;
        }
        */
    }
}
