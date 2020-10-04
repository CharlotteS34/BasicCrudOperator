using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrudOperator
{
    public interface IConverter<TSource, TResult> where TSource : class where TResult : class
    {
        TResult Convert(TSource input);
        IEnumerable<TResult> ConvertMany(IEnumerable<TSource> sources);
    }
}
