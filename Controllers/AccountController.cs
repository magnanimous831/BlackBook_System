<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BlackBook_System.Models;
=======
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BlackBook_System.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BlackBook_System.Data;
using System.Linq;
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6

namespace BlackBook_System.Controllers
{
    public class AccountController : Controller
    {
<<<<<<< HEAD
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
=======
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly BlackBookDbContext _context;

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            BlackBookDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            // If user is already authenticated, redirect to home
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            // Clean the return URL to prevent redirect loops
            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (returnUrl.StartsWith("/Account/Login") || returnUrl.Contains("//"))
                {
                    returnUrl = null;
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
=======
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (model == null)
            {
                return View();
            }

            // Clean the return URL to prevent redirect loops
            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (returnUrl.StartsWith("/Account/Login") || returnUrl.Contains("//"))
                {
                    returnUrl = null;
                }
            }

            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Always redirect to Home/Index after login
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        return RedirectUserByRole(roles);
                    }
                    // If user is null for some reason, sign out and show error
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError(string.Empty, "Unexpected error occurred. Please try again.");
                    return View(model);
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model); // make sure this is inside the if(ModelState.IsValid) block
            }

            // If model state is not valid
            return View(model);
        }
    
        // Role-based redirect
        private IActionResult RedirectUserByRole(IList<string> roles)
        {
            if (roles == null || !roles.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            if (roles.Contains(RoleConstants.Admin))
                return RedirectToAction("Index", "UserManagement");
            if (roles.Contains(RoleConstants.Principal))
                return RedirectToAction("Index", "Dashboard");
                return RedirectToAction("Index", "Leaveout_sheet");
            if (roles.Contains(RoleConstants.DeputyPrincipal))
                return RedirectToAction("Index", "Teachers_List");
                return RedirectToAction("Index", "Discipline");
            if (roles.Contains(RoleConstants.Teacher))
                return RedirectToAction("Index", "Occurrences");
                return RedirectToAction("Index", "Leaveout_sheet");
                return RedirectToAction("Index", "StudentsEnrollment");
        }
                   
          

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            ViewBag.Roles = RoleConstants.AllRoles;
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
=======
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
=======
                var user = new IdentityUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    // Ensure the role exists
                    if (!await _roleManager.RoleExistsAsync(model.Role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Role));
                    }

                    // Assign the role to the user
                    await _userManager.AddToRoleAsync(user, model.Role);

                    // Create entry in Teachers_List
                    var teachersList = new Teachers_List
                    {
                        FullName = model.FullName,
                        Gender = model.Gender,
                        Email = model.Email,
                        Username = model.Username,
                        Class = model.Role,
                        Subjects = model.Subjects,
                        Phonenumber = model.Phonenumber
                    };

                    // Add to context and save
                    _context.Teachers_List.Add(teachersList);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "User created successfully!";
                    return RedirectToAction("Index", "UserManagement");
                }

>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
<<<<<<< HEAD
=======

            ViewBag.Roles = RoleConstants.AllRoles;
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
            return View(model);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
=======
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
>>>>>>> 8fe4a8ec22a69eab55de1ed33a7dddbfc880dfa6
        }
    }
} 