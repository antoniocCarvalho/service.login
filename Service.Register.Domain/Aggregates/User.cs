

namespace Service.Register.Domain.Aggregates
{
    public class User 
    {
        public Guid Id { get; private set;  }
        public string Name { get; private set; }
        public string Senha { get; private set; }


        public User() { }


        public User(string name, string senha)
        {
            Name = name;
            Senha = senha;

        }
       
    }
}




