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
       

    }
}
