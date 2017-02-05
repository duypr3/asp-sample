using Entity;
using System.Collections;

namespace Services.Interface
{
    public interface ILoginService : IBaseService<Login>
    {
        void AddOrUpdate(string username);    
    }
}