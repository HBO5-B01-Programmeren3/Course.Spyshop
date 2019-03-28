using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Spyshop.Domain.Settings;
using Course.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Course.Spyshop.Web.Controllers
{
    public class AboutController : Controller
    {
        private SpyShopConfig spyShopConfig;

        public AboutController(IOptionsSnapshot<SpyShopConfig> spyshopconfig)
        {
            spyShopConfig = spyshopconfig.Value;
        }

        public IActionResult Index()
        {
            var viewModel = new AboutIndexVm();
            viewModel.ContactEmail = spyShopConfig.MailSettings.PublicInfoAddress;
            viewModel.CompanyFullName = spyShopConfig.FullCompanyName;
            viewModel.AboutTitle = "Welcome to spyshop";
            viewModel.AboutContent =
                "<p>We deliver premium gadgets to help all Clouseaus and Bonds out there. <br /> To start, have a look at the <a href=\"/\">homepage</a>!</p>";

            return View(viewModel);
        }
    }
}