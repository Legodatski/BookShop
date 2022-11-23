using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
    }
}
