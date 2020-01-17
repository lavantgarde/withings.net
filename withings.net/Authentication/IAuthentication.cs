using System.Threading.Tasks;

namespace withings.net.Authentication
{
    public interface IAuthentication
    {
        Task<string> GetGetAuthorizationCode();
    }
}