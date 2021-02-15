using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Ticket_CRUD.Models;

namespace Ticket_CRUD.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult>CreateUserAsync(SignUpModel userModel);
        Task<SignInResult> PasswordSignInAsync(LogInModel logInModel);
        Task SignOutAsync();
}
}
    