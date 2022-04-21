namespace AccountingProgram.Infrastructure
{
    using System.Security.Claims;

    using static AccountingProgram.Areas.ChiefAccountant.ChiefAccountantConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        { 
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsChiefAccountant(this ClaimsPrincipal user)
        {
            return user.IsInRole(ChiefAccountantRoleName);
        }
    }
}
