﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        DbContext GetDbContext();
        IBaseRepository<T> GetRepository<T>();
    }
}
