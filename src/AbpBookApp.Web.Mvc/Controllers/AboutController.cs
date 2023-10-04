using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpBookApp.Controllers;

namespace AbpBookApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AbpBookAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
