using Azure.Core;
using Service.Register.Application.Abstractions;
using Service.Register.Application.Abstractions.Features;
using Service.Register.Application.Abstractions.Features.Request;
using Service.Register.Domain.Aggregates;
using Service.Register.Infra.Data;
using Service.Register.Infra.Data.Features;
using System.Text.Json;
using System.Threading.Tasks;


namespace Service.Register.Application.Features
{
    public class UserService : IUsersService
    {

        private const string INVALID_REQUEST = "Erro";


        private readonly IUserRepository _userRepository;
        private readonly UserContext _context;
        public UserService( UserContext context,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }


        public async Task<CommandResponse<string>> Create(UserCreateRequest request)
        {
            request.Validate();

            if (!request.IsValid)
            {
                return CommandResponseFactory.Failure<string>(request.Notifications, INVALID_REQUEST);
            }

            var generatedId = Guid.NewGuid().ToString();



            var user = new User(
                 request.Name,
                 request.Senha);



            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return CommandResponseFactory.Success<string>("Usuário criado com sucesso!");
        }

        public async Task<CommandResponse<string>> GetUserById(string Id)
        {
            var user = await _userRepository.GetUserByIdAsync(Id);


            if (user == null)
            {
                return CommandResponseFactory.Failure<string>($"Usuário com o ID {Id} não encontrado.");
            }

            // Serializa o objeto inteiro ou campos específicos, se necessário
            var serializedUser = JsonSerializer.Serialize(new
            {
                user.Id, 
                user.Name,
                // Adicione outros campos se necessário
            });

            //return CommandResponseFactory.Success<string>($"Usuário: {user.Name} CPF: {user.Cpf}")
            return CommandResponseFactory.Success<string>(serializedUser);
        }



        public async Task<CommandResponse<string>> ValidarUser(LoginRequest user)
        {
            var usuario = await _userRepository.ValidarUser(user);

            if (usuario == null)
            {
                throw new Exception("Usuário ou senha inválidos.");
            }


            var userInfo = JsonSerializer.Serialize(new
            {
                usuario.Id,
                usuario.Name,
            });
            return CommandResponseFactory.Success<string>(usuario.Name);
        }


            
     }


            
        }
    








