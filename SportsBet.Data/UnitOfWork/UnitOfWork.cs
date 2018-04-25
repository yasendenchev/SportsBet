using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportsBetContext context;

        public UnitOfWork(SportsBetContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
