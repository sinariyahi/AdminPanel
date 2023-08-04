using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ISubcategoriesRepository
    {
        Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken);
        Task<Subcategory> FindSubcategoryAsync(int id, CancellationToken cancellationToken);
        Task<Subcategory> UpdateSubcategoryAsync(Subcategory subcategory, CancellationToken cancellationToken);

    }
}
