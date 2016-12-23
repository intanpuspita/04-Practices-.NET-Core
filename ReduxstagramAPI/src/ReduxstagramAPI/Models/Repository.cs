using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReduxstagramAPI.Data;

namespace ReduxstagramAPI.Models
{
    public class Repository<T> where T : class
    {
        private bool disposed = false;
        private DbAppContext context = null;
        protected DbSet<T> dbset { get; set; }

        public Repository()
        {
            //this.context = new DbAppContext()
            dbset = this.context.Set<T>();
        }


    }
}
