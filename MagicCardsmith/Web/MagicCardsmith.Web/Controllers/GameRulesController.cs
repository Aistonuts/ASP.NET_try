﻿using MagicCardsmith.Data.Models;
using MagicCardsmith.Web.ViewModels.Home;

namespace MagicCardsmith.Web.Controllers
{
    using MagicCardsmith.Services.Data;
    using MagicCardsmith.Web.ViewModels.GameRules;
    using Microsoft.AspNetCore.Mvc;

    public class GameRulesController : Controller
    {
        private readonly IGameRulesService gameRulesService;

        public GameRulesController(IGameRulesService gameRulesService)
        {
            this.gameRulesService = gameRulesService;
        }

        public IActionResult GetRules()
        {
            var rules = this.gameRulesService.Get<GameRulesViewModel>();
            rules.GameRulesComponents = this.gameRulesService.GetAll<RulesComponentsListViewModel>();
            return this.View(rules);
        }
    }
}
