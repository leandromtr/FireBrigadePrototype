using MapaDaForca.Core.Store;
using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Home.Controllers
{
    [Authorize]
    [Authorize(Roles = PerfilAcesso.Bombeiro + ", " + PerfilAcesso.Administrador)]

    public class HomeController : Controller
    {
        private readonly IBombeiroStore _bombeiroStore;
        private readonly IEscalaStore _escalaStore;
        private readonly UserManager<Bombeiro> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(
            UserManager<Bombeiro> userManager,
            RoleManager<IdentityRole> roleManager,

            IBombeiroStore bombeiroStore,
            IEscalaStore escalaStore)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _bombeiroStore = bombeiroStore;
            _escalaStore = escalaStore;
        }

        public IActionResult Index()
        {

            //var userId = _userManager.GetUserId(HttpContext.User);
            var escalas = _escalaStore.GetByBombeiroIdAndYear(new Guid(_userManager.GetUserId(HttpContext.User)), (int)DateTime.Now.Year);
            return View(escalas);
        }

    }
}
