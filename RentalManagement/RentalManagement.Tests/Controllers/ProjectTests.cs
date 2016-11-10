using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentalManagement;
using RentalManagement.Controllers;
using RentalManagement.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RentalManagement.Tests.Controllers
{
    [TestClass]
    public class ProjectTests
    {
        //Home Controller
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AboutPage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void ContactPage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        //Accounts Controller
        [TestMethod]
        public void GetAccountLogin()
        {
            // Arrange
            AccountController controller = new AccountController();
            string returnUrl = null;

            // Act
            ViewResult result = controller.Login(returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual("Login", result.ViewName);
        }

        //[TestMethod]
        //DOES NOT WORK
        //public async Task BadLoginAttempt()
        //{
        //    Debugger.Break();
        //    // Arrange
        //    AccountController controller = new AccountController();
        //    LoginViewModel model = new LoginViewModel();
        //    model.Email ="badexample@wrong.com";
        //    model.Password = "thisshouldntwork";
        //    string returnUrl = "";

        //    // Act
        //    var result = await controller.Login(model,returnUrl);
        //    var resultAsViewResult = result as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Login", resultAsViewResult.ViewName);
        //}

        [TestMethod]
        public void GetAccountRegister()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.Register() as ViewResult;

            // Assert
            Assert.AreEqual("Register", result.ViewName);
        }

        [TestMethod]
        public void GetForgotPassword()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.ForgotPassword() as ViewResult;

            // Assert
            Assert.AreEqual("ForgotPassword", result.ViewName);
        }

        [TestMethod]
        public void GetForgotPasswordConfirmation()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.ForgotPasswordConfirmation() as ViewResult;

            // Assert
            Assert.AreEqual("ForgotPasswordConfirmation", result.ViewName);
        }

        [TestMethod]
        public void GetResetPasswordFail()
            //null code, expected error
        {
            // Arrange
            AccountController controller = new AccountController();
            string code = null;

            // Act
            ViewResult result = controller.ResetPassword(code) as ViewResult;

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void GetResetPasswordPass()
        {
            // Arrange
            AccountController controller = new AccountController();
            string code = "A correct code";

            // Act
            ViewResult result = controller.ResetPassword(code) as ViewResult;

            // Assert
            Assert.AreEqual("ResetPassword", result.ViewName);
        }

        [TestMethod]
        public void GetResetPasswordConfirmation()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.ResetPasswordConfirmation() as ViewResult;

            // Assert
            Assert.AreEqual("ResetPasswordConfirmation", result.ViewName);
        }

        [TestMethod]
        public void ExternalLoginFailure()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.ExternalLoginFailure() as ViewResult;

            // Assert
            Assert.AreEqual("ExternalLoginFailure", result.ViewName);
        }





        //
    }
}
