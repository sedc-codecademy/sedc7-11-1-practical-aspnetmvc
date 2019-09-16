using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enumerations
{
    public enum OrderStatusType
    {
        Init = 0,
        Processing,
        Confirmed,
        Delivered,
        Declined
    }
}
