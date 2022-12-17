using BRMDesktopUI.Models;
using System.Threading.Tasks;

namespace BRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}