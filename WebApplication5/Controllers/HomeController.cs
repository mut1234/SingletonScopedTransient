using Microsoft.AspNetCore.Mvc;
using ServiceScope.Services;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private ISingletonService _singleton;
        private IScopedService _scoped;
        private ITransientService _transient;
        private Helper _helper;

        public HomeController(
            ISingletonService singleton,
            IScopedService scoped,
            ITransientService transient,
            Helper helper)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
            _helper = helper;
            Debug.WriteLine("_singleton", _singleton.GetGuid());
            Debug.WriteLine("scoped", _scoped.GetGuid());
            Debug.WriteLine("transient", _transient.GetGuid());

        }

        public IActionResult Index()
        {
            _helper.Test();
            return View("Index", _singleton.GetGuid());
            //return View(_singleton.GetGuid());
        }

        public IActionResult Scoped()
        {
            return View("Scoped", _scoped.GetGuid());
            //return View(_scoped.GetGuid());
        }

        public IActionResult Transient()
        {
            return View("Transient", _transient.GetGuid());
            //return View();
        }
    }

    public class Helper
    {
        private ISingletonService _singleton;
        private IScopedService _scoped;
        private ITransientService _transient;
        public Helper(
           ISingletonService singleton,
           IScopedService scoped,
           ITransientService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;

            Debug.WriteLine("_singleton", _singleton.GetGuid());
            Debug.WriteLine("scoped", _scoped.GetGuid());
            Debug.WriteLine("transient", _transient.GetGuid());
        }

        public void Test()
        {
            
        }
    }
}