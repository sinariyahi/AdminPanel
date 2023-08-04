using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class PagedList<T>
    {
        public long TotalCount { get; set; }
        public ICollection<T> list { get; set; }
    }
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile profile);
    }
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile(IEnumerable<IHaveCustomMapping> haveCustomMappings)
        {
            foreach (var item in haveCustomMappings)
                item.CreateMappings(this);
        }
    }

}
