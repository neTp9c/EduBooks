using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Api.Services
{
    public interface IConverter<TSource, TDestination>
    {
        TDestination Convert(TSource source);
    }
}