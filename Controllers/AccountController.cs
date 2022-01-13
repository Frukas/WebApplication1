using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<OperatorModel> userManager;
        private readonly SignInManager<OperatorModel> signInManager;

        public AccountController(UserManager<OperatorModel> userManager, 
            SignInManager<OperatorModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]       
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new OperatorModel { UserName = model.UserName };
                var result = await userManager.CreateAsync(user, model.Password);

                Console.WriteLine(model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {            

            if (ModelState.IsValid)
            {                

                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password,
                    model.RememberMe, false) ;                

                if (result.Succeeded)
                {                    
                    return RedirectToAction("index", "Home");
                }                
                
                ModelState.AddModelError(string.Empty, "Invalid login Attempt.");         

            }

            return View(model);
        }


    }
}
