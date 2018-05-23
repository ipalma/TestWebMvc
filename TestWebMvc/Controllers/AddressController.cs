using Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TestWebMvc.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IService<Address> _addressService;
        public AddressController(IService<Address> addressService)
        {
            _addressService = addressService;
        }
        // GET: Address
        public ActionResult Index()
        {
            ICollection<Address> addressList = _addressService.Get(_controllerName,"GetAddresses");
            return View(addressList);
        }
        public ActionResult Details(int id)
        {
            Address address = _addressService.Get(_controllerName, "GetAddress", id);
            return View(address);
        }
    }
}