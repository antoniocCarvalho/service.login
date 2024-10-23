using Service.Register.Application.Abstractions;
using Service.Register.Application.Abstractions.Features.Request;
using Service.Register.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Register.Infra.Data.Features
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<User?> GetUserByIdAsync(string Id);

        Task<User?> ValidarUser(LoginRequest user);
    }
}
