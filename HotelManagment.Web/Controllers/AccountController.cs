using AutoMapper;
using HotelManagment.Web.ViewModels;
using HotelManagment.Core.Entities;
using HotelManagment.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HotelManagment.Web.Controllers;

public class AccountController : Controller
{
  private const string ACTION_MAIN_PAGE = "Index";
  private const string CONTROLLER_MAIN_PAGE = "Home";

  private readonly IMapper _mapper;
  private readonly IUserService _userService;
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly UserManager<IdentityUser> _userManager;

  public AccountController(IMapper mapper,
    IUserService userService,
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager)
  {
    _mapper = mapper;
    _userService = userService;
    _signInManager = signInManager;
    _userManager = userManager;
  }

  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login([FromForm] LoginUserVm userVm)
  {
    if (!ModelState.IsValid)
    {
      return View(userVm);
    }

    SignInResult result = await _signInManager.PasswordSignInAsync(userVm.Username, userVm.Password, true, true);

    if (!result.Succeeded)
    {
      AddErrorsToModelState(result.IsLockedOut, result.IsNotAllowed);
      return View(userVm);
    }
    
    return RedirectToAction(ACTION_MAIN_PAGE, CONTROLLER_MAIN_PAGE);
  }

  [HttpGet]
  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterUserVm userVm)
  {
    if (!ModelState.IsValid)
    {
      return View(userVm);
    }

    IdentityUser identityUser = _mapper.Map<IdentityUser>(userVm);
    IdentityResult result = await _userManager.CreateAsync(identityUser, userVm.Password);

    if (!result.Succeeded)
    {
      foreach (IdentityError error in result.Errors)
      {
        ModelState.AddModelError("", error.Description);
      }
      
      return View(userVm);
    }

    User user = _mapper.Map<User>(userVm);

    _userService.Create(user);
    
    await _signInManager.SignInAsync(identityUser, true);

    return RedirectToAction(ACTION_MAIN_PAGE, CONTROLLER_MAIN_PAGE);
  }

  private void AddErrorsToModelState(bool isLocked, bool isNotAllowed)
  {
    if (isLocked)
    {
      ModelState.AddModelError("", "Enter is locked. Wait a little please.");
    }

    if (isNotAllowed)
    {
      ModelState.AddModelError("", "Incorrect data.");
    }
  }
}