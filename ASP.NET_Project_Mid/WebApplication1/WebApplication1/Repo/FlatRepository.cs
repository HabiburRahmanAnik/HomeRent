using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.VM;

namespace WebApplication1.Repo
{
    public class FlatRepository
    {
        static HomeRentEntities db;
        static FlatRepository()
        {
            db = new HomeRentEntities();
        }
        public static FlatModel Get(int FlatId)
        {
            var f = (from fl in db.Flats
                     where fl.FlatId == FlatId
                     select fl).FirstOrDefault();
            return new FlatModel()
            {
                FlatId = f.FlatId,
                Location = f.Location,
                Rent = f.Rent,
                FlatSize = f.FlatSize

            };
        }
        public static List<FlatModel> GetAll()
        {
            var flats = new List<FlatModel>();
            foreach (var f in flats)
            {
                FlatModel fl = new FlatModel()
                {
                    FlatId = f.FlatId,
                    Location = f.Location,
                    Rent = f.Rent,
                    FlatSize = f.FlatSize
                };
                flats.Add(fl);
            }
            return flats;
        }
    }
}