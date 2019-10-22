using System.Linq;
using System.Web.Mvc;


namespace MvcLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserSys objUser)
        {
            if (ModelState.IsValid)
            {
                using (Entities1 db = new Entities1())
                {
                    var obj = db.UserSys.Where(a => a.Login.Equals(objUser.Login) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Login"] = obj.Login;
                        var urObj =db.UserRole.Where(a => a.Id.Equals(obj.UserRoleId)).FirstOrDefault();
                        if(urObj != null)
                        {
                            if (urObj.IsAdmin)
                                return RedirectToAction("AdminDashBoard");
                            else
                                return RedirectToAction("UserDashBoard");
                        }
                    }
                }
            }
            ViewBag.Message = "The email and / or password entered is invalid.Please try again.";
            return View(objUser);
        }

        // Purpose to show skills :P
        // Redirecton to DMZ
        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                Session["isAdmin"] = "0";
                return RedirectToAction("DashBoard", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult AdminDashBoard()
        {
            if (Session["Id"] != null)
            {
                Session["isAdmin"] = true;
                return RedirectToAction("DashBoard", "Dashboard");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
