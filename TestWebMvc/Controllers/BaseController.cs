using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebMvc.Controllers
{
    public class BaseController : Controller
    {
        public string _controllerName { get { return ControllerContext.RouteData.Values["controller"].ToString(); } }
        
    }
}