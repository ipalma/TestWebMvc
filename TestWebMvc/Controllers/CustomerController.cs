using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebMvc.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IService<Customer> _customerService;
        private string _controller = string.Empty;

        public CustomerController(IService<Customer> customerService)
        {
            _customerService = customerService;
            _controller = ControllerContext.RouteData.Values["controller"].ToString();
        }
        // GET: Customer
        public ActionResult Index()
        {
            ICollection<Customer> customerList = _customerService.Get(_controllerName, "GetCustomers");
            return View(customerList);
        }
        public ActionResult Details(int id)
        {
            Customer customer = _customerService.Get(_controllerName, "GetCustomer", id);
            return View(customer);
        }
    }
}