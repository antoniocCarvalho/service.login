using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Register.Application.Abstractions.Features.Request
{
    public class LoginRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
