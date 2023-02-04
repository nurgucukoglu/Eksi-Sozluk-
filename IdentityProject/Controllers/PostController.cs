using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using IdentityProject.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<AppUser> _userManager;


        public PostController(IPostService postService, UserManager<AppUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            post.AppUserID = sender.Id;
            _postService.TInsert(post);
            return RedirectToAction("Index","Home");

        }
    }
}
