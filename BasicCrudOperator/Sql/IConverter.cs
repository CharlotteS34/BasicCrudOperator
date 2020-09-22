using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrudOperator
{
    public interface IConverter<TInput, TOutput> where TInput : class where TOutput : class
    {
        TOutput Convert(TInput input);
    }
}
