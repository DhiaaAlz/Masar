using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using AlwasataNew.Models;
using AlwasataNew.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace AlwasataNew.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager=userManager;
            _roleManager=roleManager;
        }


        public IActionResult Index()
        {
            var users =  _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                RolesName = _userManager.GetRolesAsync(user).Result
            }).ToList();

            users = users.Where(x=>x.RolesName.FirstOrDefault() != "Customer").ToList();
            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);

            if (user == null)
                NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRoleViewModel
            {
                userId = user.Id,
                userName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected=_userManager.IsInRoleAsync(user,role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);

            if (user == null)
                NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach(var role in model.Roles)
            {
                if(userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }

                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> AddNewUser()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleViewModel { RoleId = r.Id, RoleName = r.Name }).ToListAsync();

            var ViewModel = new AddUserViewModel
            {
                Roles = roles
            };

            return View(ViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Please Select At Least One Role");
                return View(model);
            }

            if(await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email is Aleady Exist !");
                return View(model);
            }
            var username = "";
            if (model.Email != null && model.Password != null)
            {
                username = new EmailAddressAttribute().IsValid(model.Email) ? new MailAddress(model.Email).User : model.Email;
            }

            if (await _userManager.FindByNameAsync(username) != null)
            {
                ModelState.AddModelError("UserName", "User Name is Aleady Exist !");
                return View(model);
            }

            
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed=true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
                return View(model);
            }

            await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                NotFound();


            var viewModel = new ProfileFormViewModel
            {
                Id=userId,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                UserName=user.UserName

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(ProfileFormViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                NotFound();


            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userWithSameEmail != null && userWithSameEmail.Id!=model.Id)
            {
                ModelState.AddModelError("Email", "this Email is already assigned to another user !");
                return View(model);
            }



            var userWithSameUserName = await _userManager.FindByNameAsync(model.UserName);

            if (userWithSameUserName != null && userWithSameUserName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "this Username is already assigned to another user !");
                return View(model);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

    }
}
