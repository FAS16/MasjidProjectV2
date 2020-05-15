using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasjidProjectV2.Models;

namespace MasjidProjectV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db;

        public UsersController()
        {
            db = new ApplicationDbContext();

        }
        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.ToList();

            var viewModel = new UsersViewModel
            {
                Users = users

            };

            return View(viewModel);
        }

        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }
    }
}