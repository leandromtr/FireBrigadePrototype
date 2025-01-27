using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapaDaForca.Areas.Identity.Pages.Account
{
    //[Authorize(Roles = PerfilAcesso.Bombeiro + ", " + PerfilAcesso.Administrador)]
    //[Authorize(Roles = PerfilAcesso.Administrador)]
    [Authorize]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Bombeiro> _signInManager;
        private readonly UserManager<Bombeiro> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IPostoStore _postoStore;
        private readonly IQuartelStore _quartelStore;
        //private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Bombeiro> userManager,
            SignInManager<Bombeiro> signInManager,
            RoleManager<IdentityRole> roleManager,
            IPostoStore postoStore,
            IQuartelStore quartelStore,
            ILogger<RegisterModel> logger)
        //IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
            _logger = logger;
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            //[Required]
            //[Display(Name = "Nome")]
            //public string Nome { get; set; }

            //[Required]
            //[Display(Name = "Nº Mecanográfico")]
            //public int NumeroMecanografico { get; set; }


            public Bombeiro Bombeiro { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve ter de {2} até {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar password")]
            [Compare("Password", ErrorMessage = "Os passwords devem ser iguais.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            //this.ViewData["Postos"] =_postoStore.GetAll();

            //this.ViewData["Quartel"] = _quartelStore.GetAll();

            var postos = _postoStore.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Nome
            }).ToList();
            ViewData["Postos"] = postos;

            var quarteis = _quartelStore.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Nome
            }).ToList();
            ViewData["Quarteis"] = quarteis;

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new Bombeiro
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nome = Input.Bombeiro.Nome,
                    NumeroMecanografico = Input.Bombeiro.NumeroMecanografico,
                    DtInicio = Input.Bombeiro.DtInicio,
                    PostoId = Input.Bombeiro.PostoId,
                    QuartelId = Input.Bombeiro.QuartelId,
                    Turno = (Turno.T1),
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var x = await _roleManager.RoleExistsAsync(PerfilAcesso.Bombeiro);

                    if (x)
                        await _userManager.AddToRoleAsync(user, PerfilAcesso.Bombeiro);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return LocalRedirect(returnUrl);
                    return new RedirectToActionResult("Detail", "Bombeiro", new { @id = user.Id, @message = true });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }


            var postos = _postoStore.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Nome
            }).ToList();
            ViewData["Postos"] = postos;

            var quarteis = _quartelStore.GetAll().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Nome
            }).ToList();
            ViewData["Quarteis"] = quarteis;

            return Page();
        }
    }
}
