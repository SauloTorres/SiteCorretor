using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SiteCorretor.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public abstract partial class AdminController : Controller
    {

    }
}