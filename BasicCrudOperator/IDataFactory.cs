using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BasicCrudOperator
{
    public interface IDataFactory<TModel> where TModel : class
    {
        TModel Create(TModel model);

        TModel Update(TModel model);

        void Delete(object key);

        TModel GetByKey(object key);

        IEnumerable<TModel> GetAll();
    }
}
