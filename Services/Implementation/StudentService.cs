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
    /*public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IBaseRepository<Student> _studentRepo;
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _studentRepo = UnitOfWork.GetRepository<Student>();
        }
        public bool IsExistedStudent(string userName)
        {
            return true;
        }
        public Student GetByName(string name)
        {
            return _studentRepo.Get(n => n.Name == name).FirstOrDefault();
        }
    }*/
}
