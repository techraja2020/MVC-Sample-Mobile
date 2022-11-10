using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Jai.Models;
namespace MVC_Jai.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult EmployeeAct()
        {
            var emp = new Employee();
            emp.EmpName = "Arjun";
            return View(emp);
        }
        [HttpPost]
        public ActionResult EmployeeAct(Employee emp)
        {
            if(ModelState.IsValid)
            {
                //saveDB()
            }
            else
            {
                ViewBag.error = string.Join(" | ", ModelState.Values
         .SelectMany(v => v.Errors)
         .Select(e => e.ErrorMessage));
            }
            return View(emp);
        }
        public ActionResult Index()
        {
            List<Employee> eModel = new List<Employee>();
            var e1 = new Employee() { EmpName = "Raja", EmpAge = 39, EmpSalary = 300000 };
            var e2 = new Employee() { EmpName = "Jai", EmpAge = 24, EmpSalary = 45000 };
            var e3 = new Employee() { EmpName = "Selvi", EmpAge = 21, EmpSalary = 25000 };
            eModel.Add(e1);
            eModel.Add(e2);
            eModel.Add(e3);
            ViewBag.MyName = "Raja Mohamed";
            return View(eModel);
        }
        [HttpGet]
        public ActionResult viewBagTempDataSample()
        {
            ViewBag.MyName = "Raja Mohamed";
            ViewData["MyName"] = "Raja M";
            TempData["MyName"] = "Jai";
            return View();
        }
        [HttpPost]
        public ActionResult viewBagTempDataSample(string ss)
        {
          // var a= ViewData["MyName"];
           // var b=TempData["MyName"];
            return RedirectToAction("MobilesShop");
        }
            [HttpGet]
            [Authorize]
        public ActionResult MobilesShop()
        {
            var a = ViewData["MyName"];
            var b = TempData["MyName"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-V9D6J83;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=ArjunShop";
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandText = "select * from mobile";


            SqlDataReader dr = com.ExecuteReader();
            List<Mobile> mob = new List<Mobile>();
            while (dr.Read())
            {
                Mobile m = new Mobile();
                m.ModelNumber = dr[0].ToString();
                m.Price = Convert.ToInt32(dr[1]);
                m.Brand = dr[2].ToString();
                m.Discount = Convert.ToInt32(dr[1]) / 10;
                mob.Add(m);

            }
            //var MobModel = mob.Where(x => x.Brand == "Nokia").ToList();
            // IEnumerable<Mobile> mobModel = mob.Select(x => new List<Mobile()> { x.Brand, x.ModelNumber, x.Price, x.Discount }).ToList<Mobile>();
            return View(mob);
            
        }
        [HttpGet]
        public ActionResult MobilesShopPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MobilesShopPost(Mobile mob)
        {
            //create veg --- insert query
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-V9D6J83;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=ArjunShop";
           
                con.Open();
           

            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandText = "insert into mobile values('"+mob.ModelNumber+"','" + mob.Price + "','" + mob.Brand + "')";
            com.ExecuteNonQuery();

            return RedirectToAction("MobilesShop");
        }

        //[ActionFilter]
        
        public ActionResult Mobile()
        {
            ViewBag.title = "Raja Mohamed";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-V9D6J83;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=ArjunShop";
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {

            }

            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandText = "select * from mobile";


            SqlDataReader dr = com.ExecuteReader();
            List<Mobile> mob = new List<Mobile>();
            while (dr.Read())
            {
                Mobile m = new Mobile();
                m.ModelNumber = dr[0].ToString();
                m.Price = Convert.ToInt32(dr[1]);
                m.Brand = dr[2].ToString();
                m.Discount = Convert.ToInt32(dr[1])/10;
                mob.Add(m);

            }
            //var MobModel = mob.Where(x => x.Brand == "Nokia").ToList();
           // IEnumerable<Mobile> mobModel = mob.Select(x => new List<Mobile()> { x.Brand, x.ModelNumber, x.Price, x.Discount }).ToList<Mobile>();
            return View(mob);
        }
    }
}