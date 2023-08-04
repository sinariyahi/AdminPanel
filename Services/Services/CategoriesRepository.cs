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
   

    public class CategoriesRepository : IBaseSevice, ICategoriesRepository
    {
        private readonly IRepository<Category> _categuryRepository;
        protected readonly IMapper _mapper;

        public CategoriesRepository(IRepository<Category> categuryRepository, IMapper mapper)
        {
            _categuryRepository = categuryRepository;
            _mapper = mapper;
        }
        public async Task<Category> AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _categuryRepository.AddAsync(category, cancellationToken);
            return category;
        }
        public async Task<Category> UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _categuryRepository.UpdateAsync(category, cancellationToken);
            return category;
        }
        public async Task<Category> FindCategoryAsync(int id, CancellationToken cancellationToken)
        {
            var cat = await _categuryRepository.GetByIdAsync(cancellationToken, id);
            return cat;
        }
        public async Task<PagedList<CateGoryGridView>> GetAll(int pageNumber, int pageSize, string name, CancellationToken cancellationToken)
        {
            var outPut = new PagedList<CateGoryGridView>();
            var t = _categuryRepository.TableNoTracking.Where(x => x.Name.Contains(name)).OrderByDescending(d => d.Id);
            outPut.TotalCount = await t.CountAsync();
            outPut.list = await t.Skip(pageNumber * pageSize).Take(pageSize).ProjectTo<CateGoryGridView>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return outPut;
        }
        /* private ApplicationDbContext context;

         public CategoriesRepository(ApplicationDbContext context)
         {
             this.context = context;
         }

         public void AddCategory(Category category)
         {
             context.Categories.Add(category);
             context.SaveChanges();
         }

         public void RemoveCategory(Category category)
         {
             context.Categories.Remove(category);
             context.SaveChanges();
         }

         public void UpdateCategory(Category category)
         {
             context.Update(category);
             context.SaveChanges();
         }

         public Category GetCategory(int id)
         {
             return context.Categories.Find(id);
         }

         public ICollection<Category> GetAllCategories()
         {
             return context.Categories.ToList();
         }

         public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
         {
             return context.Subcategories.Where(s => s.CategoryID == id).ToList();
         }

         public ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20)
         {
             return context.Products.Where(p => p.CategoryID == id)
                 .Skip((page - 1) * limit).Take(limit)
                 .ToList();
         }
        */
    }
}
