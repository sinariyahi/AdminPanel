using AutoMapper;
using Domain.Entities;
using InfraStructure;
using InfraStructure.Contracts;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SubcategoriesRepository : IBaseSevice , ISubcategoriesRepository
    {
        private readonly IRepository<Subcategory> _subcategoriesRepository;
        protected readonly IMapper _mapper;

        public SubcategoriesRepository(IRepository<Subcategory> subcategoriesRepository, IMapper mapper)
        {
            _subcategoriesRepository = subcategoriesRepository;
            _mapper = mapper;
        }
        public async Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken)
        {
            await _subcategoriesRepository.AddAsync(subcategory, cancellationToken);
            return subcategory;
        }
        public async Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken)
        {
            await _subcategoriesRepository.UpdateAsync(subcategory, cancellationToken);
            return subcategory;
        }
        public async Task<Subcategory> FindSubcategoryAsync(int id, CancellationToken cancellationToken)
        {
            var sub = await _subcategoriesRepository.GetByIdAsync(cancellationToken, id);
            return sub;
        }

    }
}
