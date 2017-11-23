using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcBasicWalkthrough.Controllers;

namespace MvcBasicWalkthrough.Tests.Controllers
{
    [TestClass]
    public class MapsControllerTest
    {
        [TestMethod]
        public void ViewMaps()
        {
            // Arrange
            MapsController controller = new MapsController(); 
            
            // Act
            ViewResult result = controller.ViewMaps() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
        }
    }
}