namespace Vic.SportsStore.WebApp.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
