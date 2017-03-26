using Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;
       /* public StudentController(IStudentService studenService, IClassService classService)
        {
            _studentService = studenService;
            _classService = classService;
        }
        public Class GetByID(long id)
        {
            return _classService.GetByID(id);
        }
        public Student GetStudentByID(long id)
        {
            return _studentService.GetByID(id);
        }*/
    }
}