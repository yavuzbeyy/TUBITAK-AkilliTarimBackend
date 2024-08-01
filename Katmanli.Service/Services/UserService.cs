using AutoMapper;
using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.ServiceInterfaces;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly ITokenCreator _tokenCreator;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper, ITokenCreator tokenCreator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenCreator = tokenCreator;
        }

        public async Task<IResponse<string>> Create(UserCreate model)
        {
            try
            {
                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                };

                await _userRepository.AddAsync(newUser);
                return new SuccessResponse<string>(Messages.Save("User"));
            }
            catch (Exception ex)
            {
                return new ErrorResponse<string>($"Failed to create user: {ex.Message}");
            }
        }

        public async Task<IResponse<string>> Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("User"));
            } 
            _userRepository.Delete(user);
            return new SuccessResponse<string>(Messages.Delete("User"));
        }

        public IResponse<UserQuery> FindById(int id)
        {
            var user = _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return new ErrorResponse<UserQuery>(Messages.NotFound("User"));
            }

            var mappedUser = _mapper.Map<UserQuery>(user);
            return new SuccessResponse<UserQuery>(mappedUser);

        }

        public IResponse<UserQuery> GetUserByUsername(string username)
        {
            var user = _userRepository.Where(u => u.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return new ErrorResponse<UserQuery>(Messages.NotFound("User"));
            }

            var mappedUser = _mapper.Map<UserQuery>(user);
            return new SuccessResponse<UserQuery>(mappedUser);
        }

        public IResponse<IEnumerable<UserQuery>> ListAll()
        {
            var users =  _userRepository.GetAll();
            var mappedUsers = _mapper.Map<IEnumerable<UserQuery>>(users);
            return new SuccessResponse<IEnumerable<UserQuery>>(mappedUsers);
        }

        public IResponse<string> Login(UserLoginDto loginModel)
        {
            var girisYapanKullanici = _userRepository.Queryable().Where(x => x.Username == loginModel.Username).FirstOrDefault();

            if (girisYapanKullanici != null)
            {
                var roles = _userRoleRepository.GetAll().Where(x => x.UserId == girisYapanKullanici.Id).Select(x => x.RoleId).ToList();

                string token = _tokenCreator.GenerateToken(loginModel.Username, roles);

                return new SuccessResponse<string>(token);
            }

            return new ErrorResponse<string>(Messages.NotFound("Token"));
        }

        public async Task<IResponse<UserQuery>> Update(UserUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
