using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IClassService : IBaseService<Class>
    {
        bool IsExistedStudent(string userName);
        Class GetByName(string name);
    }
}
