using Entity;
using Services.Interface;
using System.Web.Http;

namespace Server.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public string AddOrUpdate(string username)
        {
            Login lg = new Login()
            {
                Username = username,
                Password = "123456"
            };
            _loginService.Insert(lg);

            return "";
        }
    }
}