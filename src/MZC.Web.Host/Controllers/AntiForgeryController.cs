using MZC.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace MZC.Web.Host.Controllers
{
    public class AntiForgeryController : MZCControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}