using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class UserDTO: IHaveCustomMapping
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<UserDTO, User>();
            mappingExpression.ReverseMap();
        }
    }
    public class UserGridView : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<UserGridView, User>();
            mappingExpression.ReverseMap();            
        }

    }
}
