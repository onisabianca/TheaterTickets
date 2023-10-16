﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Models
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);
        void Update(T entity);
    }
}
