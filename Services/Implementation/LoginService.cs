using DAL;
using Entity;
using Services.Interface;

namespace Services.Implementation
{
    public class LoginService : BaseService<Login>, ILoginService
    {
        private readonly IBaseRepository<Login> _loginRepo;
        public LoginService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _loginRepo = UnitOfWork.GetRepository<Login>();
        }

        public void AddOrUpdate(string username)
        {
            
        }
    }
}