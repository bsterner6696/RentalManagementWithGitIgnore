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
using System.Data;

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

        //DOES NOT WORK
        //[TestMethod]
        //public async Task PostAccountRegister()
        //{
        //    // Arrange
        //    AccountController controller = new AccountController();
        //    RegisterViewModel model = new RegisterViewModel();
        //    model.Email = "email@test.com";
        //    model.Password = "Password1";
        //    model.ConfirmPassword = "Password1";

        //    // Act
        //    var result = await controller.Register(model);
        //    var redirect = result as RedirectToRouteResult;

        //    // Assert
        //    Assert.IsInstanceOfType(redirect, typeof(RedirectToRouteResult));
        //}

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





        // Apartment
        [TestMethod]
        public void ApartmentsDetailsWithNullId()
        {
            // Arrange
            ApartmentsController controller = new ApartmentsController();
            int? id = null;

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOfType(result,typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void ApartmentsGetCreate()
        {
            // Arrange
            ApartmentsController controller = new ApartmentsController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create",result.ViewName);
        }

        //DOES NOT WORK
        [TestMethod]
        public void ApartmentsPostCreate()
        {
            // Arrange
            //Mock<>
            ApartmentsController controller = new ApartmentsController();
            Apartment apartment = new Apartment();

            // Act
            var result = controller.Create(apartment) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void ApartmentsGetEditWithNullId()
        {
            // Arrange
            ApartmentsController controller = new ApartmentsController();
            int? id = null;

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void ApartmentsGetDeleteWithNullId()
        {
            // Arrange
            ApartmentsController controller = new ApartmentsController();
            int? id = null;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }





        // Maintenance Requests
        [TestMethod]
        public void MaintenanceRequestsDetailsWithNullId()
        {
            // Arrange
            MaintainenceRequestsController controller = new MaintainenceRequestsController();
            int? id = null;

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void MaintenanceRequestsGetCreate()
        {
            // Arrange
            MaintainenceRequestsController controller = new MaintainenceRequestsController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void MaintenanceRequestsGetEditWithNullId()
        {
            // Arrange
            MaintainenceRequestsController controller = new MaintainenceRequestsController();
            int? id = null;

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void MaintenanceRequestsGetDeleteWithNullId()
        {
            // Arrange
            MaintainenceRequestsController controller = new MaintainenceRequestsController();
            int? id = null;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }










        //Rental Properties
        [TestMethod]
        public void RentalPropertiesDetailsWithNullId()
        {
            // Arrange
            RentalPropertiesController controller = new RentalPropertiesController();
            int? id = null;

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void RentalPropertiesGetCreate()
        {
            // Arrange
            RentalPropertiesController controller = new RentalPropertiesController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void RentalPropertiesGetEditWithNullId()
        {
            // Arrange
            RentalPropertiesController controller = new RentalPropertiesController();
            int? id = null;

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void RentalPropertiesGetDeleteWithNullId()
        {
            // Arrange
            RentalPropertiesController controller = new RentalPropertiesController();
            int? id = null;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }









        //Tenants
        [TestMethod]
        public void TenantsDetailsWithNullId()
        {
            // Arrange
            TenantsController controller = new TenantsController();
            int? id = null;

            // Act
            var result = controller.Details(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void TenantsGetCreate()
        {
            // Arrange
            TenantsController controller = new TenantsController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TenantsGetEditWithNullId()
        {
            // Arrange
            TenantsController controller = new TenantsController();
            int? id = null;

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void TenantsGetDeleteWithNullId()
        {
            // Arrange
            TenantsController controller = new TenantsController();
            int? id = null;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }










        //Manage Controller
        [TestMethod]
        public void ManageGetAddPhoneNumber()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            var result = controller.AddPhoneNumber() as ViewResult;

            // Assert
            Assert.AreEqual("AddPhoneNumber", result.ViewName);
        }

        [TestMethod]
        public void ManageGetChangePassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            var result = controller.ChangePassword() as ViewResult;

            // Assert
            Assert.AreEqual("ChangePassword", result.ViewName);
        }

        [TestMethod]
        public void ManageGetSetPassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            var result = controller.SetPassword() as ViewResult;

            // Assert
            Assert.AreEqual("SetPassword", result.ViewName);
        }
    }
}
