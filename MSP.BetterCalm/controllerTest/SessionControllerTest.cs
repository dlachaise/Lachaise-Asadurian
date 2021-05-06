using MSP.BetterCalm.BusinessLogic.Interface;
using System.Linq;
using MSP.BetterCalm.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using MSP.BetterCalm.WebApi.Controllers;
using MSP.BetterCalm.WebApi.Models;


namespace MSP.BetterCalm.WebApi.Test
{
    [TestClass]
    public class SessionControllerTest
    {

        private Mock<ISessionLogic> Mock;
        private SessionController controller;
        IEnumerable<Session> sessionList;
        Session session1;

        [TestInitialize]
        public void Setup()
        {

            Mock = new Mock<ISessionLogic>(MockBehavior.Strict);
            controller = new SessionController(Mock.Object);
        }

        [TestMethod]
        public void GetLoginOK()
        {
        }
        [TestMethod]
        public void GetLoginFail()
        {


        }
    }
}