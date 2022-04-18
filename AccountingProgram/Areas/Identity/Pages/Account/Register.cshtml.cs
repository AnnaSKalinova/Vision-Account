namespace AccountingProgram.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using AccountingProgram.Data.Models;
    using static AccountingProgram.Areas.UserConstants;
    using static AccountingProgram.Data.DataConstants.User;
    using AccountingProgram.Data;
    using AccountingProgram.Services.Accountants;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IAccountantService accountants;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAccountantService accountants)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountants = accountants;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Full name")]
            [StringLength(UserFullNameMaxLength, MinimumLength = UserFullNameMinLength)]
            public string FullName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string UserType { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User 
                {
                    Email = Input.Email,
                    FullName = Input.FullName,
                    UserName = Input.Email,
                    IsAccountant = Input.UserType == UserTypeAccountant
                };

                var result = await userManager.CreateAsync(user, Input.Password);

                if (user.IsAccountant)
                {
                    this.accountants.AddAccountant(user.Id);
                }

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
