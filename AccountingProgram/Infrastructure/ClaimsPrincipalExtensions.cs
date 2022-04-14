namespace AccountingProgram.Infrastructure
{
    using System.Security.Claims;

    using static AccountingProgram.Areas.ChefAccountant.ChefAccountantConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        { 
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static bool IsChefAccountant(this ClaimsPrincipal user)
        {
            return user.IsInRole(ChefAccountantRoleName);
        }
    }
}
