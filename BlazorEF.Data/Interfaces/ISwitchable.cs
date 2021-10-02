using System;
using System.Collections.Generic;
using System.Text;
using BlazorEF.Data.Enums;

namespace BlazorEF.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
