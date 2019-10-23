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
                    /*
                                 GenderT = 0,
                     */
                    ViewBag.printSeller = adm;
                    ViewBag.GenderId = new SelectList(MvcLogin.Models.CustomersModel.getGenderId(id), "GenderId", "GenderId");
                    ViewBag.CityId = new SelectList(MvcLogin.Models.CustomersModel.getCityId(id), "CityId", "CityId");
                    ViewBag.LastPurchase = new SelectList(MvcLogin.Models.CustomersModel.getLastPurchase(id), "LastPurchase", "LastPurchase");
                    ViewBag.RegionId = new SelectList(MvcLogin.Models.CustomersModel.getRegionId(id), "RegionId", "RegionId");
                    ViewBag.ClassificationId = new SelectList(MvcLogin.Models.CustomersModel.getClassificationId(id), "ClassificationId", "ClassificationId");
                    ViewBag.UserId = new SelectList(MvcLogin.Models.CustomersModel.getUserId(id), "UserId", "UserId");
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
                
               // if (ModelState.IsValid) avoid standard check crash session
               // {
                    //objUser.Name
                    int id = System.Convert.ToInt32(Session["Id"]);
                    int adm = System.Convert.ToInt32(Session["isAdmin"]);
                    var query = "SELECT * FROM CUSTOMER";
                    if (!(objUser.Name == null))
                    {
                        if (objUser.Name.Length > 0)
                        {
                            query += " WHERE Name LIKE '%" + objUser.Name + "%'";
                        }
                    }
                    if(objUser.UserId.GetValueOrDefault() > 0)
                    {
                    if (!(query.Contains("WHERE")))
                        query += " WHERE";
                    else if ((query.Contains("=")) || (query.Contains("LIKE")))
                        query += " AND";
                        query += " UserId=" + objUser.UserId.GetValueOrDefault().ToString();
                    }
                    if (objUser.LastPurchase.HasValue)
                    {
                        if (!(query.Contains("WHERE")))
                            query += " WHERE";
                        else if ((query.Contains("=")) || (query.Contains("LIKE")))
                            query += " AND";
                        query += " LastPurchase='" + objUser.LastPurchase.ToString() + "'";
                    }
                    if(objUser.ClassificationId.GetValueOrDefault() > 0)
                    {
                        if (!(query.Contains("WHERE")))
                            query += " WHERE";
                        else if ((query.Contains("=")) || (query.Contains("LIKE")))
                            query += " AND";
                        query += " ClassificationId=" + objUser.ClassificationId.GetValueOrDefault().ToString();
                    }
                    if(objUser.GenderId > 0)
                    {
                        if (!(query.Contains("WHERE")))
                            query += " WHERE";
                        else if ((query.Contains("=")) || (query.Contains("LIKE")))
                            query += " AND";
                        query += " GenderId=" + objUser.GenderId.ToString();
                    }
                    if(objUser.RegionId.GetValueOrDefault() > 0)
                    {
                        if (!(query.Contains("WHERE")))
                            query += " WHERE";
                        else if ((query.Contains("=")) || (query.Contains("LIKE")))
                            query += " AND";
                        query += " RegionId=" + objUser.RegionId.GetValueOrDefault().ToString();
                    }
                    if (objUser.CityId.GetValueOrDefault() > 0)
                    {
                        if (!(query.Contains("WHERE")))
                            query += " WHERE";
                        else if ((query.Contains("=")) || (query.Contains("LIKE")))
                            query += " AND";
                        query += " CityId=" + objUser.CityId.GetValueOrDefault().ToString();
                    }
                    query += ";";
                    MvcLogin.Models.CustomersModel.delConnectionModel(id);
                    using (Entities1 db = new Entities1())
                    {
                        var res = db.Database.SqlQuery<GridUserViewer_Result>(query);
                        MvcLogin.Models.CustomersModel.addConnectionModel(id, res.ToList());
                    }
                    ViewBag.printSeller = adm;
                    if(objUser.GenderId > 0)
                        ViewBag.GenderId = new SelectList(MvcLogin.Models.CustomersModel.getGenderId(id), "GenderId", "GenderId", objUser.GenderId);
                    else
                        ViewBag.GenderId = new SelectList(MvcLogin.Models.CustomersModel.getGenderId(id), "GenderId", "GenderId");
                    if(objUser.CityId.GetValueOrDefault() > 0)
                        ViewBag.CityId = new SelectList(MvcLogin.Models.CustomersModel.getCityId(id), "CityId", "CityId", objUser.CityId);
                    else
                        ViewBag.CityId = new SelectList(MvcLogin.Models.CustomersModel.getCityId(id), "CityId", "CityId");
                    if(objUser.LastPurchase.HasValue)
                        ViewBag.LastPurchase = new SelectList(MvcLogin.Models.CustomersModel.getLastPurchase(id), "LastPurchase", "LastPurchase", objUser.LastPurchase);
                    else
                        ViewBag.LastPurchase = new SelectList(MvcLogin.Models.CustomersModel.getLastPurchase(id), "LastPurchase", "LastPurchase");
                    if (objUser.RegionId.GetValueOrDefault() > 0)
                        ViewBag.RegionId = new SelectList(MvcLogin.Models.CustomersModel.getRegionId(id), "RegionId", "RegionId", objUser.RegionId);
                    else
                        ViewBag.RegionId = new SelectList(MvcLogin.Models.CustomersModel.getRegionId(id), "RegionId", "RegionId");
                    if(objUser.ClassificationId.GetValueOrDefault() > 0)
                        ViewBag.ClassificationId = new SelectList(MvcLogin.Models.CustomersModel.getClassificationId(id), "ClassificationId", "ClassificationId", objUser.ClassificationId);
                    else
                        ViewBag.ClassificationId = new SelectList(MvcLogin.Models.CustomersModel.getClassificationId(id), "ClassificationId", "ClassificationId");
                    if(objUser.UserId.GetValueOrDefault() > 0)
                        ViewBag.UserId = new SelectList(MvcLogin.Models.CustomersModel.getUserId(id), "UserId", "UserId", objUser.UserId);
                    else
                        ViewBag.UserId = new SelectList(MvcLogin.Models.CustomersModel.getUserId(id), "UserId", "UserId");


                    return View(MvcLogin.Models.CustomersModel.getConnectionModel(id));
                //}
                //else
                //    return RedirectToAction("Login", "Home");
            }
        }
    }
}
