using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InvenTrackCore.Infrastructure.Persistence.Repositories;

public class UsersRepository : GenericRepository<Users>, IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Users> UserByEmail(string email)
    {
        var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email!.Equals(email));
        return user!;
    }

    public async Task<Users> UserByUsername(string username)
    {
        var user = await _context.Users
            .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName!.Equals(username));
        return user!;
    }
}