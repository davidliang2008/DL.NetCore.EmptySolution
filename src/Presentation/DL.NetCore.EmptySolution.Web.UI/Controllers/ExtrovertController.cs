using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.NetCore.EmptySolution.Data.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace DL.NetCore.EmptySolution.Web.UI.Controllers
{
    public class ExtrovertController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ExtrovertController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
