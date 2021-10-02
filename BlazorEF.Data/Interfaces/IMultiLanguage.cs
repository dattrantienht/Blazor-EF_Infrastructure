using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEF.Data.Interfaces
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { set; get; }
    }
}
