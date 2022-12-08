﻿using NP.Utilities;
using NP.Utilities.Attributes;
using NP.Utilities.BasicServices;
using System.Security;

namespace MockAuthentication;

[Implements(typeof(IAuthenticationService), IsSingleton = true)]
public class MockAuthenticationService : VMBase, IAuthenticationService
{
    [Part]
    private ILog? Log { get; set; }

    private string? _currentUserName;
    public string? CurrentUserName 
    { 
        get => _currentUserName;
        private set
        {
            if (_currentUserName == value)
                return;

            _currentUserName = value;

            OnPropertyChanged(nameof(CurrentUserName));
            OnPropertyChanged(nameof(IsAuthenticated));
        }
    }

    // Is authenticated is true if and only if the CurrentUserName is not zero
    public bool IsAuthenticated => CurrentUserName != null;

    public bool Authenticate(string userName, string password)
    {
        if (IsAuthenticated)
        {
            throw new Exception("Already Authenticated");
        }

        CurrentUserName =
                (userName == "nick" && password == "1234") ? userName : null;

        if (IsAuthenticated)
        {
            Log?.Log
            (
                LogKind.Info,
                nameof(IAuthenticationService),
                $"Authenticated user '{userName}'");
        }

        return IsAuthenticated;
    }

    public void Logout()
    {
        if (!IsAuthenticated)
        {
            throw new Exception("Already logged out");
        }

        CurrentUserName = null;
    }
}
