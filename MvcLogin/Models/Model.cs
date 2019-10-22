using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace MvcLogin.Models
{
    struct connectionModels
    {
        public connectionModels(int Id, List<GridViewer_Result> Grid)
        {
            this.Id = Id;
            this.Grid = Grid;
        }

        public int Id { get; set; }

        public List<GridViewer_Result> Grid { get; set; }
    }

    public class ddlGenderId
    {
        public int GenderId { get; set; }
    }

    public class ddlLastPurchase
    {
        public int LastPurchase { get; set; }
    }

    public class ddlCityId
    {
        public int CityId { get; set; }
    }

    public class ddlRegionId
    {
        public int RegionId { get; set; }
    }

    public class ddlClassificationId
    {
        public int ClassificationId { get; set; }
    }

    public class ddlUserId
    {
        public int UserId { get; set; }
    }

    public class GridViewer_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<System.DateTime> LastPurchase { get; set; }
        public Nullable<int> ClassificationId { get; set; }
        public Nullable<int> UserId { get; set; }
    }


    public class CustomersModel
    {
        public List<GridUserViewer_Result> Customers { get; set; }


        static public List<GridViewer_Result> getConnectionModel(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Grid;
            return new List<GridViewer_Result>();
        }

        static public void delConnectionModel(int Id)
        {
            var item = Grids.Single(r => r.Id == Id);
            Grids.Remove(item);
        }

        // To user friedly model, like put 'Male' ou 'Femalle' otherwise 1 or 2
        // And another expansions
        static public void addConnectionModel(int Id, List<GridUserViewer_Result> Grid)
        {
            List<GridViewer_Result> l = new List<GridViewer_Result>();
            foreach (var g in Grid)
            {
                GridViewer_Result g0 = new GridViewer_Result();
                g0.Id = g.Id;
                g0.Name = g.Name;
                g0.Phone = g.Phone;
                g0.GenderId = g.GenderId;
                g0.CityId = g.CityId;
                g0.RegionId = g.RegionId;
                g0.LastPurchase = g.LastPurchase;
                g0.ClassificationId = g.ClassificationId;
                g0.UserId = 0;
                l.Add(g0);
            }
            Grids.Add(new connectionModels(Id, l));
        }

        // To user friedly model, like put 'Male' ou 'Femalle' otherwise 1 or 2
        // And another expansions
        static public void addConnectionModel(int Id, List<GridAdminViewer_Result> Grid)
        {
            List<GridViewer_Result> l = new List<GridViewer_Result>();
            foreach (var g in Grid)
            {
                GridViewer_Result g0 = new GridViewer_Result();
                g0.Id = g.Id;
                g0.Name = g.Name;
                g0.Phone = g.Phone;
                g0.GenderId = g.GenderId;
                g0.CityId = g.CityId;
                g0.RegionId = g.RegionId;
                g0.LastPurchase = g.LastPurchase;
                g0.ClassificationId = g.ClassificationId;
                g0.UserId = g.UserId;
                l.Add(g0);
            }
            Grids.Add(new connectionModels(Id, l));
        }

        static private List<connectionModels> Grids = new List<connectionModels>();

    }
}