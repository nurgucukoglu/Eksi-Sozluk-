using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using IdentityProject.Helper;
using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager, IPostService postService)
        {
            _userManager = userManager;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {

            var userInfo = LayoutInfo.GetUserData(User.Identity.Name);
            ViewBag.UserPhoto = userInfo.ImageUrl;
            ViewBag.userID = userInfo.Id;
            ViewBag.UserName = userInfo.UserName;

            var values =_postService.TGetList();

            foreach (var item in values)
            {
                    item.AppUser = await _userManager.FindByIdAsync(item.AppUserID.ToString());
            }

            return View(values);
        }

       
    }
}
