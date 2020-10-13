using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCrudOperator.Sql
{
    public class SqlExpandedDataFactory<TModel, TEntity> : SqlDataFactory<TModel, TEntity>, IExpandedDataFactory<TModel> where TModel : class where TEntity : class
    {
        public SqlExpandedDataFactory(IConverter<TModel, TEntity> modelToEntity, IConverter<TEntity, TModel> entityToModel, IContext context) : base(modelToEntity, entityToModel, context)
        {
        }

        public int Count() => table.Count();

        public int CountWhere(Func<TModel, bool> where) => table.Select(x => EntityToModel.Convert(x)).Count(x => where(x));

        public IEnumerable<TModel> GetWhere(Func<TModel, bool> where) => table.Select(x => EntityToModel.Convert(x)).Where(x => where(x));
    }
}
