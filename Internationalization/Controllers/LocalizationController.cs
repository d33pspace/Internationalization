using System;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Internationalization.Controllers
{
    public class LocalizationController : BaseController
    {

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            SetLanguage(culture);
            return LocalRedirect(returnUrl);
        }

        public IActionResult ToggleLanguage(string returnUrl)
        {
            var feature = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var currentCulture = feature.RequestCulture.Culture;
            var culture = currentCulture.Name == "en-US" ? "zh-CN" : "en-US";
            SetLanguage(culture);
            return LocalRedirect(returnUrl);
        }
    }
}