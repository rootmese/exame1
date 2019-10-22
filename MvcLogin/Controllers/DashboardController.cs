using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MvcLogin.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["Login"] == null)
                return RedirectToAction("Login", "Home");
            else
            {
                if (ModelState.IsValid)
                {
                    int id = System.Convert.ToInt32(Session["Id"]);
                    int adm = System.Convert.ToInt32(Session["isAdmin"]);
                    using (Entities1 db = new Entities1())
                    {
                        if (adm == 1)
                        {
                            System.Data.Objects.ObjectResult<GridAdminViewer_Result> res0;
                            res0 = db.GridAdminViewer();
                            MvcLogin.Models.CustomersModel.addConnectionModel(id, res0.ToList());
                        }
                        else
                        {
                            System.Data.Objects.ObjectResult<GridUserViewer_Result> res1;
                            res1 = db.GridUserViewer(System.Convert.ToInt32(Session["Id"]));
                            MvcLogin.Models.CustomersModel.addConnectionModel(id, res1.ToList());
                        }
                    }
                    ViewBag.printSeller = adm;
                    return View(MvcLogin.Models.CustomersModel.getConnectionModel(id));
                }
                else
                    return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dashboard(MvcLogin.Models.GridViewer_Result objUser)
        {
            if (Session["Login"] == null)
                return RedirectToAction("Login", "Home");
            else
            {
                
                if (ModelState.IsValid)
                {
                    int id = System.Convert.ToInt32(Session["Id"]);
                    int adm = System.Convert.ToInt32(Session["isAdmin"]);
                    using (Entities1 db = new Entities1())
                    {
                        if (adm == 1)
                        {
                            System.Data.Objects.ObjectResult<GridAdminViewer_Result> res0;
                            res0 = db.GridAdminViewer();
                            MvcLogin.Models.CustomersModel.addConnectionModel(id, res0.ToList());
                        }
                        else
                        {
                            System.Data.Objects.ObjectResult<GridUserViewer_Result> res1;
                            res1 = db.GridUserViewer(System.Convert.ToInt32(Session["Id"]));
                            MvcLogin.Models.CustomersModel.addConnectionModel(id, res1.ToList());
                        }
                    }
                    ViewBag.printSeller = adm;
                    return View(MvcLogin.Models.CustomersModel.getConnectionModel(id));
                }
                else
                    return RedirectToAction("Login", "Home");
            }
        }
    }
}
