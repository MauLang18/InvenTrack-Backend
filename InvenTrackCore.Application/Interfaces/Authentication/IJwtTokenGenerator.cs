using InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Users user);
}