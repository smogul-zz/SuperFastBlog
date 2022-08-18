using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperFastBlogAPI.Controllers;
using SuperFastBlogAPI.Models;
using System;

namespace SuperFastBlogAPI.Tests.Controllers
{
    [TestClass]
    public class ArticleControllerTest
    {
        ApiStatus returnStatus = new ApiStatus();


        Article moqData = new Article()
        {
            ID = 1,
            Content = "lorem epsum",
            DatePosted = DateTime.Today,
            Heading = "There was once",
            Image = new byte[1],
            PostedUserID = 2,
            Topic = "Health"
        };

        [TestMethod]
        public void GetArticlesTest()
        {
            // Arrange
            ArticleController controller = new ArticleController();

            // Act
            returnStatus = controller.GetArticles();

            // Assert
            Assert.IsNotNull(returnStatus);
            Assert.AreEqual(1, returnStatus);
           
        }

        [TestMethod]
        public void GetArticleTest()
        {
            // Arrange
            ArticleController controller = new ArticleController();

            // Act
            returnStatus = controller.GetArticle(5);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

        [TestMethod]
        public void AddArticleTest()
        {
            // Arrange
            ArticleController controller = new ArticleController();


            // Act
            returnStatus = controller.AddArticle(moqData);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

        [TestMethod]
        public void UpdateArticleTest()
        {
            // Arrange
            ArticleController controller = new ArticleController();

            // Act
            returnStatus = controller.UpdateArticle(1, moqData);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

        [TestMethod]
        public void RemoveArticleTest()
        {
            // Arrange
            ArticleController controller = new ArticleController();

            // Act
           returnStatus =  controller.RemoveArticle(5);

            // Assert
            Assert.AreEqual(1, returnStatus.Code);
        }

    }
}
