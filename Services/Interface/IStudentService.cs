using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IStudentService : IBaseService<Student>
    {
        bool IsExistedStudent(string userName);
        Student GetByName(string name);
    }
}
