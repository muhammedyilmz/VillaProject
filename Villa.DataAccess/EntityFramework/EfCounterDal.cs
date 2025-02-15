using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.Repositories;
using Villa.Entity.Entities;

namespace Villa.DataAccess.EntityFramework
{
    public class EfCounterDal : GenericRepository<Counter>, ICounterDal
    {
        public EfCounterDal(VillaContext context) : base(context)
        {
        }
    }
}