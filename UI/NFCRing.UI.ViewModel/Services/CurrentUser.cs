﻿using NFCRing.Service.Common;
using System.DirectoryServices.AccountManagement;

namespace NFCRing.UI.ViewModel.Services
{
    public static class CurrentUser
    {
        public static int MaxTokensCount = 100;

        public static string Get()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        public static bool IsValidCredentials(string username, string password)
        {
            if(Crypto.IsDomainJoined()) // check if we're on a domain
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    return context.ValidateCredentials(username, password);
                }
            }
            else
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    return context.ValidateCredentials(username, password);
                }
            }
        }
    }
}