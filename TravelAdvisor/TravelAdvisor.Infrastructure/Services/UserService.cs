﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<UserCreateDto> Create(UserCreateDto newUser)
        {
      
            throw new NotImplementedException();
        
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<UserUpdateDto> Update()
        {
            throw new NotImplementedException();
        }

        public ClaimsIdentity Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return id;
        }

        //Denna method letar efetr en user via inmatade email //Merran
        public User GetByEmail(string email)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        //Denna method letar efetr en user via inmatade email och password //Merran
        public User GetByEmailAndPassword(string email, string password)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
