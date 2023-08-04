using AutoMapper;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class OrderPageDto
    {
        public ShippingMethod ShippingMethod { get; set; }
        public ICollection<OrderFeature> OrderFeatures;
        public ICollection<OrderDetail> Details { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
    public class OrderGridView : IHaveCustomMapping
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string ApplicationUserID { get; set; }
        public int ShippingMethodID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Note { get; set; }
        public decimal ShippingMethodPrice { get; set; }
        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<OrderGridView, Order>();
            mappingExpression.ReverseMap();
            //CustomMappings(mappingExpression.ReverseMap());
        }

    }
}

