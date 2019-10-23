using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace MvcLogin.Models
{
    public struct connectionModels
    {
        public connectionModels
            (
            int Id,
            List<GridViewer_Result> Grid,
            List<ddlGenderId> Gender,
            List<ddlCityId> City,
            List<ddlRegionId> Region,
            List<ddlLastPurchase> Purchase,
            List<ddlClassificationId> Classification,
            List<ddlUserId> User
            )
        {
            this.Id = Id;
            this.Grid = Grid;
            this.Gender = Gender;
            this.City = City;
            this.Purchase = Purchase;
            this.Region = Region;
            this.Classification = Classification;
            this.User = User;
        }

        public int Id { get; set; }
        public List<GridViewer_Result> Grid { get; set; }
        public List<ddlGenderId> Gender { get; set; }
        public List<ddlCityId> City { get; set; }
        public List<ddlLastPurchase> Purchase { get; set; }
        public List<ddlRegionId> Region { get; set; }
        public List<ddlClassificationId> Classification { get; set; }
        public List<ddlUserId> User { get; set; }
    }


    public class ddlGenderId
    {
        public int GenderId { get; set; }
    }

    public class ddlLastPurchase
    {
        public System.DateTime LastPurchase { get; set; }
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

    public class _ddlGenderId
    {
        public _ddlGenderId()
        {
            _list = new List<ddlGenderId>();
        }
        public void add_ddlGenderId(int GenderId)
        {
            foreach(var g in _list)
                if(g.GenderId == GenderId)
                    return;
            ddlGenderId n = new ddlGenderId();
            n.GenderId = GenderId;
            _list.Add(n);
        }

        public List<ddlGenderId> get_ddlGenderId()
        {
            return _list;
        }

        private List<ddlGenderId> _list;
    }

    public class _ddlCityId
    {
        public _ddlCityId()
        {
            _list = new List<ddlCityId>();
        }
        public void add_ddlCityId(int CityId)
        {
            foreach (var g in _list)
                if (g.CityId == CityId)
                    return;
            ddlCityId n = new ddlCityId();
            n.CityId = CityId;
            _list.Add(n);
        }

        public List<ddlCityId> get_ddlCityId()
        {
            return _list;
        }

        private List<ddlCityId> _list;
    }

    public class _ddlLastPurchase
    {
        public _ddlLastPurchase()
        {
            _list = new List<ddlLastPurchase>();
        }
        public void add_ddlLastPurchase(System.DateTime LastPurchase)
        {
            foreach (var g in _list)
                if (g.LastPurchase == LastPurchase)
                    return;
            ddlLastPurchase n = new ddlLastPurchase();
            n.LastPurchase = LastPurchase;
            _list.Add(n);
        }

        public List<ddlLastPurchase> get_ddlLastPurchase()
        {
            return _list;
        }

        private List<ddlLastPurchase> _list;
    }

    public class _ddlRegionId
    {
        public _ddlRegionId()
        {
            _list = new List<ddlRegionId>();
        }
        public void add_ddlRegionId(int RegionId)
        {
            foreach (var g in _list)
                if (g.RegionId == RegionId)
                    return;
            ddlRegionId n = new ddlRegionId();
            n.RegionId = RegionId;
            _list.Add(n);
        }

        public List<ddlRegionId> get_ddlRegionId()
        {
            return _list;
        }

        private List<ddlRegionId> _list;
    }

    public class _ddlClassificationId
    {
        public _ddlClassificationId()
        {
            _list = new List<ddlClassificationId>();
        }
        public void add_ddlClassificationId(int ClassificationId)
        {
            foreach (var g in _list)
                if (g.ClassificationId == ClassificationId)
                    return;
            ddlClassificationId n = new ddlClassificationId();
            n.ClassificationId = ClassificationId;
            _list.Add(n);
        }

        public List<ddlClassificationId> get_ddlClassificationId()
        {
            return _list;
        }

        private List<ddlClassificationId> _list;
    }

    public class _ddlUserId
    {
        public _ddlUserId()
        {
            _list = new List<ddlUserId>();
        }
        public void add_ddlUserId(int UserId)
        {
            foreach (var g in _list)
                if (g.UserId == UserId)
                    return;
            ddlUserId n = new ddlUserId();
            n.UserId = UserId;
            _list.Add(n);
        }
        public List<ddlUserId> get_ddlUserId()
        {
            return _list;
        }
        private List<ddlUserId> _list;
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

        static public List<ddlUserId> getUserId(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.User;
            return new List<ddlUserId>();
        }

        static public List<ddlClassificationId> getClassificationId(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Classification;
            return new List<ddlClassificationId>();
        }
        static public List<ddlLastPurchase> getLastPurchase(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Purchase;
            return new List<ddlLastPurchase>();
        }

        static public List<ddlCityId> getCityId(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.City;
            return new List<ddlCityId>();
        }

        static public List<ddlRegionId> getRegionId(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Region;
            return new List<ddlRegionId>();
        }

        static public List<ddlGenderId> getGenderId(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Gender;
            return new List<ddlGenderId>();
        }


        static public List<GridViewer_Result> getConnectionModel(int Id)
        {
            foreach (var g in Grids)
                if (g.Id == Id)
                    return g.Grid;
            return new List<GridViewer_Result>();
        }

        static public void delConnectionModel(int Id)
        {
            int i = 0;
            if (Grids.Count == 0)
                return;
            do
            {
                if(Grids[i].Id == Id)
                {
                    Grids.Remove(Grids[i]);
                    continue;
                }
            }
            while (++i < Grids.Count);
        }

        // To user friedly model, like put 'Male' ou 'Female' otherwise 1 or 2
        // And another expansions
        static public void addConnectionModel(int Id, List<GridUserViewer_Result> Grid)
        {
            List<GridViewer_Result> l = new List<GridViewer_Result>();
            if (Grid.Count > 0)
            {
                var gender = new _ddlGenderId();
                var city = new _ddlCityId();
                var region = new _ddlRegionId();
                var purchase = new _ddlLastPurchase();
                var classification = new _ddlClassificationId();
                var user = new _ddlUserId();
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
                    gender.add_ddlGenderId(g.GenderId);
                    city.add_ddlCityId(g.CityId.GetValueOrDefault());
                    region.add_ddlRegionId(g.RegionId.GetValueOrDefault());
                    purchase.add_ddlLastPurchase(g.LastPurchase.GetValueOrDefault());
                    classification.add_ddlClassificationId(g.ClassificationId.GetValueOrDefault());
                }
                var model = new connectionModels
                (
                    Id,
                    l,
                    gender.get_ddlGenderId(),
                    city.get_ddlCityId(),
                    region.get_ddlRegionId(),
                    purchase.get_ddlLastPurchase(),
                    classification.get_ddlClassificationId(),
                    user.get_ddlUserId()
                ); ;
                Grids.Add(model);
            }
        }

        // To user friedly model, like put 'Male' ou 'Femalle' otherwise 1 or 2
        // And another expansions
        static public void addConnectionModel(int Id, List<GridAdminViewer_Result> Grid)
        {
            List<GridViewer_Result> l = new List<GridViewer_Result>();
            if (Grid.Count > 0)
            {
                var gender = new _ddlGenderId();
                var city = new _ddlCityId();
                var region = new _ddlRegionId();
                var purchase = new _ddlLastPurchase();
                var classification = new _ddlClassificationId();
                var user = new _ddlUserId();
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
                    gender.add_ddlGenderId(g.GenderId);
                    city.add_ddlCityId(g.CityId.GetValueOrDefault());
                    region.add_ddlRegionId(g.RegionId.GetValueOrDefault());
                    purchase.add_ddlLastPurchase(g.LastPurchase.GetValueOrDefault());
                    classification.add_ddlClassificationId(g.ClassificationId.GetValueOrDefault());
                    user.add_ddlUserId(g.UserId.GetValueOrDefault());
                }
                var model = new connectionModels
                (
                    Id,
                    l,
                    gender.get_ddlGenderId(),
                    city.get_ddlCityId(),
                    region.get_ddlRegionId(),
                    purchase.get_ddlLastPurchase(),
                    classification.get_ddlClassificationId(),
                    user.get_ddlUserId()
                );
                Grids.Add(model);
            }
        }

        static private List<connectionModels> Grids = new List<connectionModels>();

    }
}