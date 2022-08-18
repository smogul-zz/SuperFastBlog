using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperFastBlogAPI.Controllers;
using SuperFastBlogAPI.Extensions;
using SuperFastBlogAPI.Models;
using System;

namespace SuperFastBlogAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {


        ApiStatus returnStatus = new ApiStatus();
       
        User moqData = new User()
        {
            ID = 1,
            Password = Helper.HashPassword("12345", Helper.GenerateSalt(70), 10102, 70),
            Role = (int)Roles.Admin,
            Username = "sanele@eoh"
        };

        [TestMethod]
        public void GetAllUserTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            returnStatus = controller.GetUsers();

            // Assert
            Assert.IsNotNull(returnStatus);
            Assert.AreEqual(1, returnStatus.Code);
           
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            returnStatus = controller.GetUser(moqData.ID);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            controller.UpdateUser(moqData.ID,moqData);

            // Assert
            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

       

        [TestMethod]
        public void RemoveUserTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            returnStatus = controller.RemoveUser(moqData.ID);

            // Assert
            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }
    }
}
