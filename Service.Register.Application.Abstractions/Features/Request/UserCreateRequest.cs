using Flunt.Validations;
using Flunt.Notifications;

namespace Service.Register.Application.Abstractions.Features.Request
{
   
public class UserCreateRequest : Command
    {

        public string Name { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(Name, nameof(Name), "O nome deve ser preenchido.")
              
                .IsNotNullOrEmpty(Senha, nameof(Senha), "A senha deve ser preenchida.")
                //.HasMaxLengthIfNotNullOrEmpty(Senha, 6, nameof(Senha), "A senha deve ter pelo menos 6 caracteres.")
                );
        }
    }
    }


