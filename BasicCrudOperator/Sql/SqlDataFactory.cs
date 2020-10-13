using BasicCrudOperator.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCrudOperator
{
    public class SqlDataFactory<TModel, TEntity> : IDataFactory<TModel> where TModel : class where TEntity : class
    {
        public SqlDataFactory(IConverter<TModel, TEntity> modelToEntity, IConverter<TEntity, TModel> entityToModel, IContext context)
        {
            ModelToEntity = modelToEntity;
            EntityToModel = entityToModel;
            this.context = context;
            table = context.DbContext.Set<TEntity>();
        }
        protected readonly IConverter<TModel, TEntity> ModelToEntity;
        protected readonly IConverter<TEntity, TModel> EntityToModel;
        protected readonly IContext context;
        protected DbSet<TEntity> table = null;
        public TModel Create(TModel model)
        {
            var entity = ModelToEntity.Convert(model);
            table.Add(entity);
            context.SaveChanges();
            return EntityToModel.Convert(entity);
        }

        public void Delete(object key)
        {
            var entity = table.Find(key);
            table.Remove(entity);
            context.SaveChanges();
        }

        public TModel GetByKey(object key)
        {
            var entity = table.Find(key);
            return EntityToModel.Convert(entity);
        }

        public TModel Update(TModel model)
        {
            var entity = ModelToEntity.Convert(model);
            table.Update(entity);
            context.SaveChanges();
            return EntityToModel.Convert(entity);
        }

        public IEnumerable<TModel> GetAll()
            => EntityToModel.ConvertMany(table.ToArray());
    }
}
