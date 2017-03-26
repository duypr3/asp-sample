using DAL;
using DAL.Repository;
using Entity;
using Services.Interface;

namespace Services.Implementation
{
    public class LoginService : BaseService<Login>, ILoginService
    {
        private readonly ILoginRepository _loginRepo;    

        public LoginService(ILoginRepository loginRepo) : base(loginRepo)
        {
            
        }
    }
}