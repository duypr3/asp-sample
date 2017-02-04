using DAL;
using Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ClassService : BaseService<Class>, IClassService
    {
        private readonly IBaseRepository<Class> _classRepo;
        public ClassService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _classRepo = UnitOfWork.GetRepository<Class>();
        }
        public bool IsExistedStudent(string userName)
        {
            return true;
        }
        public Class GetByName(string name)
        {
            return _classRepo.Get(n => n.Name == name).FirstOrDefault();
        }
    }
}
