using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vic.SportsStore.WebApp.Abstract
{
     public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
