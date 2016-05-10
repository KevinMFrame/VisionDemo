using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisionDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string Username = "admin";
            string Password = "apple";
            string HostAddress = "http://QBIT-CKC8R32:5896/api/v1/";

            RestCalls caller = new RestCalls(HostAddress, Username, Password);

            List<string> cubeNames = caller.GetObjectNames(RestCalls.ObjectTypes.Cubes);

            List<VisionDemo.Models.Cube> cubes = new List<VisionDemo.Models.Cube>();

            foreach (string cubeName in cubeNames)
            {
                VisionDemo.Models.Cube c = new VisionDemo.Models.Cube(cubeName);
                foreach (string viewName in caller.GetViewNamesForCube(cubeName))
                {
                    c.Views.Add(new Models.View(cubeName,viewName));
                }
                cubes.Add(c);
            }

            VisionDemo.Models.CubeViewer cubeViewer = new Models.CubeViewer(cubes);

            return View("Index",cubeViewer);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}