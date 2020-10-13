using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrudOperator
{
    public interface IExpandedDataFactory<TModel> : IDataFactory<TModel> where TModel : class
    {
        IEnumerable<TModel> GetWhere(Func<TModel, bool> where);

        int CountWhere(Func<TModel, bool> where);

        int Count();
    }
}
