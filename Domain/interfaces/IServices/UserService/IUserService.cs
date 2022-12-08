using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.interfaces.Services.UserService
{
    public interface IUserService
    {
        Task<UserEntity> GetById (Guid id);
        Task<IEnumerable<UserEntity>> GetAll ();
        Task<UserEntity> Post (UserEntity entity);
        Task<UserEntity> Put (UserEntity entity);
        Task<bool> Delete (Guid id);
    }
}
