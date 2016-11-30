using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWebApplication.Controllers;
using System.Web.Mvc;

namespace MyWebApplication.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexView()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexStringInViewbag()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.ProgressBar() as ViewResult;

            Assert.AreEqual("My Progressbar.", result.ViewBag.Message);
        }
    }
}
