using Entity;
using System.Data.Entity;

namespace DAL.Repository
{
    public interface ILoginRepository : IBaseRepository<Login>
    {

    }
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory.GetDefaultDbContext())
        {

        }
    }
}