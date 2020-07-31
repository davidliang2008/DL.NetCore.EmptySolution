using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DL.NetCore.EmptySolution.Web.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Invite()
        {
            return View();
        }
    }
}
