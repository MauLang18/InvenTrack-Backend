using InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.Interfaces.Persistence;

public interface IUsersRepository : IGenericRepository<Users>
{
    Task<Users> UserByEmail(string email);
    Task<Users> UserByUsername(string username);
}