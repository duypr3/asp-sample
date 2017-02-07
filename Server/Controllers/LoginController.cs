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

        [HttpPost]
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
        [HttpPost]
        public Login AddOrUpdateV1(Login login)
        {            
            _loginService.Insert(login);

            return login;
        }
        [HttpGet]
        public IList<Login> GetAll()
        {
            return _loginService.GetAll().ToList();
        }
        [HttpGet]
        public IList<Login> GetByInfo(string username, string password)
        {
            return _loginService.Get(n => n.Username.ToLower().Equals(username.ToLower())).ToList();
        }
    }
}