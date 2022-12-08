using Domain.Entidades;
using Domain.interfaces;
using Domain.interfaces.Services.UserService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{    
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.GetAsync();
        }

        public async Task<UserEntity> GetById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UserEntity> Post(UserEntity entity)
        {
           return await _repository.InsertAsync(entity);
        }

        public async Task<UserEntity> Put(UserEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
