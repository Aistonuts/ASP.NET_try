﻿namespace MagicCardsmith.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using MagicCardsmith.Data.Models;
    using MagicCardsmith.Services.Data;
    using MagicCardsmith.Web.ViewModels.Article;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticleController(
            IArticleService articleService,
            UserManager<ApplicationUser> userManager)
        {
            this.articleService = articleService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.articleService.CreateAsync(input, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                return this.View(input);
            }

            this.TempData["Message"] = "Article added successfully.";

            return this.RedirectToAction("Index", "Home");
        }


    }
}
