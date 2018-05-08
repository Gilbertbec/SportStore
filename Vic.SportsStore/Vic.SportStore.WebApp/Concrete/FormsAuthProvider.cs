namespace Vic.SportsStore.WebApp.Concrete
{
    using System.Web.Security;
    using Vic.SportsStore.WebApp.Abstract;

    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}
