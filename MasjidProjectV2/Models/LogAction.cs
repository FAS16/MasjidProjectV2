using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasjidProjectV2.Models
{
    public enum LogAction
    {
        LogInSuccess = 0,
        LogOut = 1,
        LogInLockedOut = 2,
        LogInFailure = 3,
        PasswordReset = 4,
        PasswordResetFailure = 5,
        PasswordResetOnNullUser = 6,
        PasswordChange = 7,
        PasswordChangeFailure = 8,
        EmailConfirmation = 9,
        UserRegistrationAccept = 10,
        UserRegistrationDecline = 12
    }
}