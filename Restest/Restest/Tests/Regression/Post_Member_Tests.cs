using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using TestingUtilities;
using TestingUtilities.Models;
using FluentAssertions;

namespace Restest.Tests.Regression
{
    [TestClass]
    public class Post_Member_Tests
    {
        BasicUtil basicUtil;
        static Browser B;
        static string Env;
        DateTime start;
        
        static TestingUtilities.Models.TestingObjects.RunItems RI;
        static TestingUtilities.Models.TestingObjects.ScriptRunner SR;
        static TestingUtilities.TestCaseManagement.QACompleteTestRun TestRun;
        static ProgramValues PV;
        
        [ClassInitialize]
        public static void ClassStart(TestContext context)
        {
            string _Client = "LoyaltyWare";
            string _ScriptName = "CS Portal Regression";
            string _Application = "RST";

            PV = new ProgramValues();
            SR = PV.GetScriptRunnerInfo(_Client, _ScriptName);
            RI = PV.GetTestingPreferencesfromRest(SR.UserName, _Application);
            RI.Client_Name = _Client;

            Env = context.GetEnvironment();
            B = new Browser(context);

            TestRun = new TestingUtilities.TestCaseManagement.QACompleteTestRun(RI);
            TestRun.QACompleteItems(SR.TestSetName);
        }
        [ClassCleanup]
        public static void ClassStop()
        {

        }

        [TestCleanup]
        public void TearDown()
        {
            B.Finish();
        }
        [TestInitialize]
        public void StartUp()
        {
            start = DateTime.Now;
          
            basicUtil = new BasicUtil();

            runTimeItems = new CSPortalTesting.Models.General.RunTimeItems(RI)
            {
                driv = this.driv,
                basicUtil = this.basicUtil,
            };

            page_login = new Pages.Login_Page(runTimeItems);
            page_memberregistration = new Pages.MemberRegistration_Page(runTimeItems);
        }

        [TestMethod]
        public void Test_1()
        {
            if (TestRun.ThisTestAlreadyPassed() == false)
            {
                page_login.login("csadmin", "csadmin");
            }
        }
    }
}
