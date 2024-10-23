using Service.Register.Application.Abstractions.Features.Request;
using Service.Register.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Register.Application.Abstractions.Features
{
    public interface IUsersService
    {
        Task<CommandResponse<string>> Create(UserCreateRequest user);
        Task<CommandResponse<string>> GetUserById(string Id);
        Task<CommandResponse<string>> ValidarUser(LoginRequest user);

    }
}
