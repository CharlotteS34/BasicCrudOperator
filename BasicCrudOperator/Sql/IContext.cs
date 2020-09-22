using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrudOperator.Sql
{
    public interface IContext : IDisposable
    {
        DbContext DbContext { get; set; }

        void SaveChanges();
    }
}
