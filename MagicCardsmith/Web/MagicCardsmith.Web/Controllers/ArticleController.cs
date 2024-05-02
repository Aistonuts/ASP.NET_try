﻿namespace MagicCardsmith.Web.Controllers
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using MagicCardsmith.Common;
    using MagicCardsmith.Data.Models;
    using MagicCardsmith.Services.Data;
    using MagicCardsmith.Web.ViewModels.Article;
    using MagicCardsmith.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ArticleController(
            IArticleService articleService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.articleService = articleService;
            this.userManager = userManager;
            this.environment = environment;
        }

       // [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit()
        {
            return this.View();
        }


        [HttpPost]
        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.articleService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.ById), new { id });
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
                await this.articleService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                return this.View(input);
            }

            this.TempData["Message"] = "Article added successfully.";

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult ById(int id)
        {
            var article = this.articleService.GetById<SingleArticleViewModel>(id);
            article.Articles = this.articleService.GetRandom<IndexPageArticleViewModel>(3);
            return this.View(article);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> ApproveArticle(int id)
        {
            await this.articleService.ApproveArticle(id);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
