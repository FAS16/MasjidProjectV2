using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasjidProjectV2.Models
{
    public enum AccountStatus
    {
        Registered = 0,
        ActivatedByAdmin = 1,
        ActivatedByUser = 2,
        LockedOut = 3
    }
}