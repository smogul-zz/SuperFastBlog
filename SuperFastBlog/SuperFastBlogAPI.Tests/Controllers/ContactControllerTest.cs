using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperFastBlogAPI.Controllers;
using SuperFastBlogAPI.Models;
using System;

namespace SuperFastBlogAPI.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        ApiStatus returnStatus = new ApiStatus();


        Contact moqData = new Contact()
        {
            ID = 1,
            Date = DateTime.Today,
            Email = "sanele@ioco.tech",
            Message = "I would like to find out if I can be an employee at iOCO",
            Name = "Sanele",
            

        };

        [TestMethod]
        public void GetAllContactsTest() {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            returnStatus = controller.GetAllContacts();

            // Assert
            Assert.IsNotNull(returnStatus);
            Assert.AreEqual(1, returnStatus);
        }

        [TestMethod]
        public void GetContactTest()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            returnStatus = controller.GetContact(moqData.ID);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

        [TestMethod]
        public void AddContactTest()
        {
            // Arrange
            ContactController controller = new ContactController();


            // Act
            returnStatus = controller.AddContact(moqData);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

       

        [TestMethod]
        public void RemoveContactTest()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            returnStatus = controller.RemoveContact(5);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }
    }
}
