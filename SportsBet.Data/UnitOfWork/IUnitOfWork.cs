﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
