using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasjidProjectV2.Models;
using MasjidProjectV2.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace MasjidProjectV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRegistrationsController : Controller
    {

        private ApplicationDbContext db;
        private ApplicationUserManager _userManager;
        private DbLogService logService;

        public UserRegistrationsController()
        {
            logService = new DbLogService();
            db = new ApplicationDbContext();
            
        }

        public UserRegistrationsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;

        }

        public ActionResult Index()
        {
            var pendingUsers = db.Users.Where(u => u.AccountStatus == AccountStatus.Registered);
            return View(pendingUsers);

        }

        public async Task<ActionResult> RegisterByAdmin(string id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            user.AccountStatus = AccountStatus.ActivatedByAdmin;

            var result = db.SaveChangesAsync();

            // Save activation link to user
            string codeForUser = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, codeForUser = codeForUser }, protocol: Request.Url.Scheme);
            logService.LogInDb(user.Email, LogAction.UserRegistrationAccept);
            await UserManager.SendEmailAsync(user.Id, "Bekræft oprettelse af brugerkonto", "Bekræft oprettelse af din bruger ved at klikke <a href=\"" + callbackUrl + "\">her</a>");

            return RedirectToAction("Index");
        }

        public ActionResult DeleteByAdmin(string id)
        {
            var user = db.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userDelete = db.Users.Remove(user);
            db.SaveChangesAsync();
            logService.LogInDb(user.Email, LogAction.UserRegistrationDecline);

            return RedirectToAction("Index");
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

            }

            base.Dispose(disposing);
        }

    }


}