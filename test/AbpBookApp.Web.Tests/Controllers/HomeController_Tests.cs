using System.Threading.Tasks;
using AbpBookApp.Models.TokenAuth;
using AbpBookApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpBookApp.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpBookAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}