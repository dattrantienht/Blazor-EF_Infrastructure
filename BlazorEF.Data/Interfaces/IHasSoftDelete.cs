using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorEF.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDeleted { set; get; }
    }
}
