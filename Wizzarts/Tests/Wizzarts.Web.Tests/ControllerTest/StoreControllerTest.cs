﻿namespace Wizzarts.Web.Tests.ControllerTest
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using MyTested.AspNetCore.Mvc;
    using Wizzarts.Services.Data.Tests;
    using Wizzarts.Web.Controllers;
    using Wizzarts.Web.ViewModels.Store;
    using Xunit;

    using static Wizzarts.Common.GlobalConstants;

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
            this.OneTimeSetup();
            var data = this.dbContext;
            MyController<StoreController>
                .Instance(instance => instance
                    .WithData(data.Users.FirstOrDefault(x => x.Id == "2b346dc6-5bd7-4e64-8396-15a064aa27a7"))
                    .WithUser(x1 => x1.WithIdentifier("2b346dc6-5bd7-4e64-8396-15a064aa27a7").WithRoleType(AdministratorRoleName)))
                .Calling(c => c.Create(With.Empty<CreateStoreViewModel>()))
                .ShouldHave()
                .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post));
            this.TearDownBase();
        }

        [Fact]
        public void CreatePostShouldReturnViewWithSameModelWhenInvalidModelState()
        {
            this.OneTimeSetup();
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
            this.TearDownBase();
        }

        [Fact]
        public void CreatePostShouldSaveArticleSetTempDataMessageAndRedirectWhenValidModel()
        {
            this.OneTimeSetup();
            var data = this.dbContext;
            Bitmap bitmapImage = new Bitmap(50, 50);
            Graphics imageData = Graphics.FromImage(bitmapImage);
            imageData.DrawLine(new Pen(Color.Blue), 0, 0, 50, 50);

            MemoryStream memoryStream = new MemoryStream();
            byte[] byteArray;

            using (memoryStream)
            {
                bitmapImage.Save(memoryStream, ImageFormat.Jpeg);
                byteArray = memoryStream.ToArray();
            }

            var imageStream = new MemoryStream(byteArray);
            var file = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            MyController<StoreController>
                   .Instance(instance => instance
                       .WithUser(x => x.WithIdentifier("2b346dc6-5bd7-4e64-8396-15a064aa27a7").AndAlso().InRole(PremiumRoleName))
                       .WithData(data.Users))
                  .Calling(c => c.Create(new CreateStoreViewModel
                  {
                      StoreName = "testTestTest",
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
            this.TearDownBase();
        }

        [Fact]
        public void AllShouldReturnDefaultViewWithCorrectModel()
        {
            this.OneTimeSetup();
            var data = this.dbContext;
            MyController<StoreController>
                        .Instance(instance => instance
                            .WithData(data.Stores.ToList()))
                        .Calling(c => c.All(1))
                        .ShouldReturn()
                        .View(view => view
                            .WithModelOfType<StoreListViewModel>());

            this.TearDownBase();
        }

        [Fact]
        public void Approve_Store_Should_Redirect_To_Correct_Location()
        {
            this.OneTimeSetup();
            var data = this.dbContext;
            var storeOwner = data.Stores.FirstOrDefault(s => s.Id == 1).StoreOwnerId;
            MyController<StoreController>
                        .Instance(instance => instance
                            .WithData(data.Stores.ToList()))
                        .Calling(c => c.ApproveStore(1))
                        .ShouldReturn()
                        .RedirectToAction("ById", "Member", new { id = $"{storeOwner}", Area = "Administration" });

            this.TearDownBase();
        }
    }
}
