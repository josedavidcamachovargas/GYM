using GYM.Areas.Identity.Pages.Account;
using GYM.Data;
using GYM.Data.GeneralSystem.IGeneralSystem;
using GYM.Models;
using GYM.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Areas.Admin.Controllers
{
    [EnableCors]
    [Area("Admin")]
    //[Route("api/users")]
    //[ApiController]
    //[Authorize(Roles = RoleNames.Role_Admin)]
    //[Authorize(Roles = RoleNames.Role_Receptionist)]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ISystemFacade _systemFacade;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public UserController(ApplicationDbContext db, ISystemFacade unitOfWork,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            SignInManager<IdentityUser> signInManager)
        {
            _context = db;
            _systemFacade = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _signInManager = signInManager;
        }

        //[Route("Index")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS
        //[Route("LockUnlock")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }

            _context.SaveChanges();

            return Json(new { success = true, message = "Operation Successfull" });

        }


        //[Route("LockUnlock")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        [HttpPost]
        public IActionResult ShowInfo([FromBody] string id)
        {
            var objFromDb = _context.ApplicationUsers.FirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }

            _context.SaveChanges();

            return Json(new { success = true, message = "Operation Successfull" });

        }



        [HttpGet]
        //[Route("GetAll")]
        public IActionResult GetAll()
        {


            var userList = _context.ApplicationUsers.ToList();
            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();

            foreach (var user in userList)
            {
                var roleID = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleID).Name;

            }
            return Json(new { data = userList });
        }


        // GET: Admin/User/Details/5
        //[Route("Details")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        public async Task<IActionResult> ShowCodeInfo(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _systemFacade.ApplicationUser
                .GetFirstOrDefault(m => m.IDCard.Equals(id));

            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();

            var roleID = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
            user.Role = roles.FirstOrDefault(r => r.Id == roleID).Name;
            ViewData["ExpirationDate"] = _context.PaymentTypes.FirstOrDefault(pt => pt.CustomerId.Equals(user.Id)).ExpirationDate;
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        //// POST: UserController/Create
        //[EnableCors]
        //[HttpPost]
        ////[Route("CreateUser/{applicationUser:ApplicationUser}")]
        ////[ValidateAntiForgeryToken]
        //public async Task<ActionResult<ApplicationUser>> CreateUserAngular([FromBody] MobileUser mobileUser)
        //{
        //    //Console.WriteLine(mobileUser.FullName.ToString());
        //    //returnUrl ??= Url.Content("~/");, string returnUrl = null
        //    //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    //if (ModelState.IsValid)
        //    //{

        //    var user = new MobileUser
        //    {
        //        UserName = mobileUser.EmailData,
        //        Email = mobileUser.EmailData,
        //        StreetAdress = mobileUser.Address,
        //        State = mobileUser.Address,
        //        City = mobileUser.Address,
        //        PostalCode = "",
        //        Name = mobileUser.FullName,
        //        Role = mobileUser.Role
        //    };
        //    var result = await _userManager.CreateAsync(user, mobileUser.Password);

        //    if (await _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Email.Equals(mobileUser.EmailData)) != null)
        //    {
        //        _unitOfWork.ApplicationUser.Update(user);
        //        _unitOfWork.Save();
        //        result = await _userManager.UpdateAsync(user);
        //    }





        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User created a new account with password.");

        //        if (!await _roleManager.RoleExistsAsync(RoleNames.Role_Admin))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(RoleNames.Role_Admin));
        //        }

        //        if (!await _roleManager.RoleExistsAsync(RoleNames.Role_User_Indi))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(RoleNames.Role_User_Indi));
        //        }

        //        if (!await _roleManager.RoleExistsAsync(RoleNames.Role_User_Kitchen))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(RoleNames.Role_User_Kitchen));
        //        }

        //        //await _userManager.AddToRoleAsync(user, RoleNames.Role_Admin);


        //        if (user.Role == null)
        //        {
        //            await _userManager.AddToRoleAsync(user, RoleNames.Role_User_Indi);
        //        }
        //        else
        //        {
        //            //if (user.CompanyID > 0)
        //            //{
        //            //    await _userManager.AddToRoleAsync(user, RoleNames.Role_User_Company);
        //            //}
        //            await _userManager.AddToRoleAsync(user, user.Role);
        //        }


        //        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //        //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        //var callbackUrl = Url.Page(
        //        //    "/Account/ConfirmEmail",
        //        //    pageHandler: null,
        //        //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
        //        //    protocol: Request.Scheme);

        //        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //        {
        //            //, returnUrl = returnUrl
        //            return RedirectToPage("RegisterConfirmation", new { email = mobileUser.EmailData });
        //        }
        //        else
        //        {
        //            if (user.Role == null)
        //            {
        //                await _signInManager.SignInAsync(user, isPersistent: false);
        //                //return LocalRedirect(returnUrl);
        //                return RedirectToAction("Index", "User", new { Area = "Admin" });
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "User", new { Area = "Admin" });
        //            }

        //        }
        //    }
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }

        //    //_unitOfWork.ApplicationUser.Add(user);
        //    //_unitOfWork.Save();

        //    return Json(new { success = true });
        //    //}

        //    //return Json(new { success = false });
        //}


        //[EnableCors]
        //[HttpPost]
        //public async Task<ActionResult<ApplicationUser>> LoginUserAngular([FromBody] MobileUser mobileUser)
        //{
        //    //returnUrl ??= Url.Content("~/");
        //    //Console.WriteLine(mobileUser.FullName.ToString());
        //    //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    //if (ModelState.IsValid)
        //    //{
        //    // This doesn't count login failures towards account lockout
        //    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //    var result = await _signInManager.PasswordSignInAsync(mobileUser.EmailData, mobileUser.Password, false, lockoutOnFailure: false);
        //    if (result.Succeeded)
        //    {
        //        _logger.LogInformation("User logged in.");
        //        return Json(new { success = true, message = "Correct", id = _db.ApplicationUsers.FirstOrDefault(u => u.Email.Equals(mobileUser.EmailData)) });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //        return Json(new { success = false, message = "Incorrect" });
        //    }
        //    //}

        //    // If we got this far, something failed, redisplay form

        //}



        // GET: Admin/User/Details/5
        //[Route("Details")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _systemFacade.ApplicationUser
                .GetFirstOrDefault(m => m.Id.Equals(id));

            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();

            var roleID = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
            user.Role = roles.FirstOrDefault(r => r.Id == roleID).Name;


            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        //[Authorize(Roles = RoleNames.Role_Admin)]
        [HttpGet]
        public async Task<IActionResult> Upsert(string? id)
        {

            ApplicationUser user = new ApplicationUser();
            ViewData["Role"] = new SelectList(_context.Roles.ToList());

            if (id == null) //create dish
            {
                return View(user);
            }

            //update dish
            user = await _systemFacade.ApplicationUser.GetFirstOrDefault(u => u.Id.Equals(id));

            if (user == null)
            { return NotFound(); }

            return View(user);
        }


        //[Authorize(Roles = RoleNames.Role_Admin)]
        [HttpGet]
        public async Task<IActionResult> CodeInfo(string? id)
        {

            ApplicationUser user = new ApplicationUser();
            ViewData["Role"] = new SelectList(_context.Roles.ToList());

            if (id == null) //create dish
            {
                return View(user);
            }

            //update dish
            user = await _systemFacade.ApplicationUser.GetFirstOrDefault(u => u.Id.Equals(id));

            if (user == null)
            { return NotFound(); }

            return View(user);
        }


        //[Authorize(Roles = RoleNames.Role_Admin)]

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Upsert(ApplicationUser user)
        {

            if (ModelState.IsValid)
            {
                if (user.Id != null)
                {
                    ApplicationUser objFromDB = await _systemFacade.ApplicationUser.GetFirstOrDefault(u => u.Id.Equals(user.Id));
                }


                if (user.Id == null)
                {
                    _systemFacade.ApplicationUser.Add(user);
                }
                else
                {
                    _systemFacade.ApplicationUser.Update(user);
                }
                _systemFacade.Save();
                return RedirectToAction(nameof(Index));

            }

            return View(user);
        }


        // GET: Admin/User/Delete/5
        //[Route("Delete2")]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _systemFacade.ApplicationUser
                .GetFirstOrDefault(m => m.Id.Equals(id));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Route("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleNames.Role_Admin)]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _systemFacade.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            _systemFacade.ApplicationUser.Remove(user);
            _systemFacade.Save();
            return RedirectToAction(nameof(Index));
        }


        //[HttpDelete]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var objFromDb = await _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);

        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    _unitOfWork.ApplicationUser.Remove(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Deleted Successfully" });
        //}

        #endregion
    }
}
