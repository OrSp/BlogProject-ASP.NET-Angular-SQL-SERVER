using BlogLab.Models.Account;
using BlogLab.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyBlog_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUserIdentity> _userManager;
        private readonly SignInManager<ApplicationUserIdentity> _signInManager;

        public AccountController(
            ITokenService tokenService,
            UserManager<ApplicationUserIdentity> userManager,
            SignInManager<ApplicationUserIdentity> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUserCreate applicationUserCreate)
        {
            var applicationUserIdentity = new ApplicationUserIdentity
            {
                Username = applicationUserCreate.Username,
                Email = applicationUserCreate.Email,
                Fullname = applicationUserCreate.Fullname
            };

            var result = await _userManager.CreateAsync(applicationUserIdentity, applicationUserCreate.Password);

            if (result.Succeeded)
            {
                applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserCreate.Username);

                ApplicationUser applicationuser = new ApplicationUser()
                {
                    ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                    Username = applicationUserIdentity.Username,
                    Email = applicationUserIdentity.Email,
                    Token = _tokenService.CreatToken(applicationUserIdentity)
                };

                return Ok(applicationuser);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]

        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUserLogin applicationUserLoging)
        {
            var applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserLoging.Username);

            if (applicationUserIdentity != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(
                    applicationUserIdentity,
                    applicationUserLoging.Password, false);

                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                        Username = applicationUserIdentity.Username,
                        Email = applicationUserIdentity.Email,
                        Fullname = applicationUserIdentity.Fullname,
                        Token = _tokenService.CreatToken(applicationUserIdentity)
                    };

                    return Ok(applicationUser);
                }
            }

            return BadRequest("Invalid login attempt.");
        }
    }
}
