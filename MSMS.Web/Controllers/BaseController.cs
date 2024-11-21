using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MSMS.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
