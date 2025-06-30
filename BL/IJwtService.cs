using final_project.models;

public interface IJwtService
{
    string GenerateToken(User user);
}