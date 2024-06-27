﻿namespace Wizzarts.Web.Infrastructure.Extensions
{
    using System.Security.Claims;

    using static Wizzarts.Common.GlobalConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdministratorRoleName);
        }
    }
}
