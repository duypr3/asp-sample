using Entity;
using Services.Interface;
using System.Collections;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public Login AddOrUpdate(string username, string password)
        {
            Login lg = new Login()
            {
                Username = username,
                Password = password
            };
            _loginService.Insert(lg);

            return lg;
        }
        public IList<Login> GetAll()
        {
            return _loginService.GetAll().ToList();
        }
    }
}