using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project_Mid.Models.VM
{
    public class FlatModel
    {
       

        public int FlatId { get; set; }
        public string FlatSize { get; set; }
        public string Location { get; set; }
        public string RoomDetails { get; set; }
        public string Rent { get; set; }
        public int UserId { get; set; }

    }
}