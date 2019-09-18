using System;
using System.Collections.Generic;
using System.Text;

namespace WebModels.Enumerations
{
    public enum OrderStatusViewType
    {
        Init = 0,
        Processing,
        Confirmed,
        Delivered,
        Declined
    }
}
