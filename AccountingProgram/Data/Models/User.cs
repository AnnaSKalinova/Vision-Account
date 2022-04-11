namespace AccountingProgram.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    
    using static AccountingProgram.Data.DataConstants.User;

    public class User : IdentityUser
    {
        [MaxLength(UserFillNameMaxLength)]
        public string FullName { get; set; }
    }
}
