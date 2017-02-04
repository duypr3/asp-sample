using Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    public class ClassController : ApiController
    {
        private readonly IClassService _classService;
        public ClassController(IClassService studenService)
        {
            _classService = studenService;
        }
        public Class GetByID(long id)
        {
           var result = _classService.Get(null,"Students").FirstOrDefault();

            return result;
        }
    }
}