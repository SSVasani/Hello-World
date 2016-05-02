using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Logic_Layer;
using MvcApplication1.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcApplication1.Controllers
{
    public class AssetsController : Controller
    {
        Logic l = new Logic();
        public ActionResult Index(int id, int mode)
        {
            Sample s = new Sample();
            DataSet ds = new DataSet();
            ds = l.editdata(id,5);
            foreach (DataRow dr in ds.Tables[0].Rows) // loop for adding add from dataset to list
            {
                s.H_name = dr["Hardware_name"].ToString();
                s.P_name = dr["Person_name"].ToString();
                s.qty = Convert.ToInt32 (dr["qty"].ToString());
                s.id = Convert.ToInt32(dr["id"].ToString());
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Index(Sample s)
        {
            l.insertdata(s, 1);
            Response.Redirect("DisplayData");
            return View();
        }

        public ActionResult DisplayData()
        {
            return View();
        }
        public JsonResult DispData()
        {
            string strdata;
            Logic l = new Logic();
            DataSet ds = new DataSet();

            ds = l.selectdata(2);
            
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    strdata = "<tr>";
                    strdata = "<td> = " + dr["Hardware_name"].ToString() + "";
                    strdata = "</td>";
                    strdata = "<td> = " + dr["Person_names"].ToString() + "";
                    strdata = "</td>";
                    strdata = "<td> = " + dr["qty"].ToString() + "";
                    strdata = "</td>";
                    strdata = "<td><a href=\"Index?Id=/" + dr["id"].ToString() + ">Edit</a>";
                    strdata = "</td>";
                    strdata = "<td><a href=\"Index?Id=/" + dr["id"].ToString() + ">Delete</a>";
                    strdata = "</td>";
                }
           
            return Json("strdata");
        }
        public JsonResult deletedata(int id)
        {
            l.deletedata(3, id);
            return Json(1);
        }
    }
}
