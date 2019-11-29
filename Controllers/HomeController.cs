using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //1private NewContext context;
        //public HomeController (NewContext _context)
        //{
        //    context = _context;
        //}
        private ICategoryReponsitory categoryReponsitory;
        private IPostReponsitory postReponsitory;
        //public HomeController(ICategoryReponsitory _categoryReponsitory)
        //{
        //    categoryReponsitory = _categoryReponsitory;
        //}
        public HomeController(IPostReponsitory _postReponsitory)
        {
            postReponsitory = _postReponsitory;
        }
        public async Task<IActionResult> Index()
        {
            //1List<Post> posts = context.Posts.ToList();
            List<Post> posts = await postReponsitory.GetAll();
            return View(posts);
        }
        [Route("xemchua/{slug}-{id:int}")]
        public async Task<ViewResult> ViewPost(int id)
        {
            return View(await postReponsitory.FindById(id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
