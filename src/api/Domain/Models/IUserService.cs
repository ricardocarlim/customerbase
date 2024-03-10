namespace api.Domain.Models
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}
