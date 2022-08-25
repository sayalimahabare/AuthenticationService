using AuthenticationService.Models;

namespace AuthenticationService.Repository.IRepository
{
    public interface IUserRepository
    {
       
        User Authenticate(string username, string password);
        
    }
}
