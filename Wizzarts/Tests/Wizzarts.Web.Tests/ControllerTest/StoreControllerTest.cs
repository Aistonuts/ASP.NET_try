﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Wizzarts.Data.Models;
using Wizzarts.Services.Data.Tests;
using Wizzarts.Web.Controllers;
using Wizzarts.Web.ViewModels.Article;
using Wizzarts.Web.ViewModels.PlayCard;
using Wizzarts.Web.ViewModels.Store;
using Xunit;
using static Wizzarts.Common.GlobalConstants;
namespace Wizzarts.Web.Tests.ControllerTest
{
    public class StoreControllerTest : UnitTestBase
    {
        [Fact]
        public void CreateGetShouldHaveRestrictionsForHttpGetOnlyAndAuthorizedUsersAndShouldReturnView()
           => MyController<StoreController>
               .Calling(c => c.Create())
               .ShouldHave()
               .ActionAttributes(attrs => attrs
                   .RestrictingForHttpMethod(HttpMethod.Get))

               .AndAlso()
               .ShouldReturn()
               .View();

        [Fact]
        public void CreatePostShouldHaveRestrictionsForHttpPostOnlyAndAuthorizedUsers()
        {
            OneTimeSetup();
            var data = this.dbContext;
            MyController<StoreController>
                .Instance(instance => instance
                    .WithData(data.Users.FirstOrDefault(x => x.Id == "2b346dc6-5bd7-4e64-8396-15a064aa27a7"))
                    .WithUser(X => X.WithIdentifier("2b346dc6-5bd7-4e64-8396-15a064aa27a7").WithRoleType(AdministratorRoleName)))
                .Calling(c => c.Create(With.Empty<CreateStoreViewModel>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post));
            TearDownBase();
        }

        [Fact]
        public void CreatePostShouldReturnViewWithSameModelWhenInvalidModelState()
        {
            OneTimeSetup();
            var data = this.dbContext;
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            IFormFile file = new FormFile(new MemoryStream(bytes), 1, bytes.Length, "Data", "dummy.jpg");

            MyController<StoreController>
                .Instance(instance => instance
                    .WithData(data.Roles)
                    .WithUser(X => X.WithIdentifier("2b346dc6-5bd7-4e64-8396-15a064aa27a7").WithRoleType(PremiumRoleName)))
                .Calling(c => c.Create(new CreateStoreViewModel
                {
                    StoreName = "test",
                    StoreOwnerId = "testtesttest",
                    StoreAddress = "testtesttesttest",
                    StoreCity = "testtesttesttest",
                    StoreCountry = "testtesttesttest",
                    StorePhoneNumber = "00000100000",
                    StoreImage = file,
                }))
                .ShouldHave()
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<CreateStoreViewModel>());
            TearDownBase();
        }

        [Fact]
        public void CreatePostShouldSaveArticleSetTempDataMessageAndRedirectWhenValidModel()
        {
            OneTimeSetup();
            var data = this.dbContext;
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            IFormFile file = new FormFile(new MemoryStream(bytes), 1, bytes.Length, "Data", "dummy.jpg");

            MyController<StoreController>
                .Instance(instance => instance
                    .WithUser(x=>x.WithIdentifier("2b346dc6-5bd7-4e64-8396-15a064aa27a7"))
                    .WithData(data.Users))
               .Calling(c => c.Create(new CreateStoreViewModel
               {
                   StoreName = "testTestTest",
                   StoreOwnerId = "2b346dc6-5bd7-4e64-8396-15a064aa27a7",
                   StoreAddress = "testtesttesttestaaaa",
                   StoreCity = "Sofia",
                   StoreCountry = "Bulgaria",
                   StorePhoneNumber = "0359222222222",
                   StoreImage = file,
               }))
               .ShouldHave()
               .ValidModelState()
               .AndAlso()
               .ShouldHave()
               .TempData(tempData => tempData
                   .ContainingEntryWithValue("Store added successfully."))
               .AndAlso()
               .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<StoreController>(c => c.All(With.No<int>())));
            TearDownBase();
        }

        [Fact]
        public void AllShouldReturnDefaultViewWithCorrectModel()
        {
            OneTimeSetup();
            var data = this.dbContext;
            MyController<StoreController>
                        .Instance(instance => instance
                            .WithData(data.Stores.ToList()))
                        .Calling(c => c.All(1))
                        .ShouldReturn()
                        .View(view => view
                            .WithModelOfType<StoreListViewModel>());

            TearDownBase();
        }
    }
}