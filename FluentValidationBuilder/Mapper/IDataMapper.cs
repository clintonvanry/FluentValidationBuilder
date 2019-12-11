using System;
using System.Text;

namespace FluentValidationBuilder.Mapper
{
    public interface IDataMapper<TFrom, TTo>
    {
        TTo MapTo(TFrom from);

        // reference map i.e. we add from the @from object attributes to the @to object
        void Map(TFrom from, TTo to);
    }


    // TODO TEst for null
}
