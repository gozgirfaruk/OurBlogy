﻿using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> MyBlogList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            // ViewBag.id = user.Id + " " + user.Name + " " + user.Surname;
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            List<SelectListItem> values = (from item in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = item.CategoryName,
                                               Value = item.CategoryID.ToString()
                                           }).ToList();
            ViewBag.Category = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserID = user.Id;
            article.WriterID = 6;
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList");
        }

        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }


        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> item = (from vol in _categoryService.TGetAll()
                                         select new SelectListItem
                                         {
                                             Text = vol.CategoryName,
                                             Value = vol.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v = item;
            var values = _articleService.TGetyById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditBlog(Article article)
        {
            _articleService.TUpdate(article);
            return RedirectToAction("MyBlogList");
        }
    }
}
