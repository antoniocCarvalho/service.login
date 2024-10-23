using Service.Register.Domain.Aggregates;
using Service.Register.Infra.Data.Features;
using Service.Register.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Service.Register.Application.Abstractions.Features.Request;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context) : base(context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(string Id)
    {

        return await _context.Users.FindAsync(Id);  
    }


    public Task<List<User>> GetAllAsync()
    {
        return DbSet.ToListAsync();
    }

    public async Task<User?> ValidarUser(LoginRequest user)
    {
        var usuario = await _context.Users
                        .FirstOrDefaultAsync(u => u.Name == user.Name && u.Senha == user.Senha);

        return usuario;
    }
}
