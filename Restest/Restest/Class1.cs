using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using Restest.Models;
using TestingUtilities;
using TestingUtilities.Models;

namespace Restest
{
    [TestClass]
    public class Class1
    {
        string token = string.Empty;
        DateTime start;
        BasicUtil basicUtil;
        TestingUtilities.Models.General.RunTimeItems runTimeItems;
        static TestingUtilities.Models.TestingObjects.RunItems RI;
        static TestingUtilities.Models.TestingObjects.ScriptRunner SR;
        static TestingUtilities.TestCaseManagement.QACompleteTestRun TestRun;
        static ProgramValues PV;
        static string Env;

        [ClassCleanup]
        public static void ClassStop()
        {

        }
        [TestCleanup]
        public void TearDown()
        {

        }

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
            
            TestRun = new TestingUtilities.TestCaseManagement.QACompleteTestRun(RI);
            TestRun.QACompleteItems(SR.TestSetName);
        }

        [TestInitialize]
        public void StartUp()
        {
            start = DateTime.Now;
            
            basicUtil = new BasicUtil();

            runTimeItems = new Restest.Models.General.RunTimeItems(RI)
            {
                basicUtil = this.basicUtil,
            };
            RestHelper restHelper = new RestHelper();
            token = restHelper.GetAuth("https://10.4.11.78:8443/lod-minor/api/v1/", "116eb1e753aa4cafbe382bf2359f3a8f", "231bbc92870c417f925d52cea3e3a03d");
        }
        [TestMethod]
        public void Test_1()
        {
            Models.Member.member member = new Member.member();
            member.username = basicUtil.RandomString(10,0,0);
            member.password = "Password1*";
            member.cards = new List<Member.card>();

            Models.Member.card card = new Member.card();
            card.isPrimary = true;
            card.cardNumber = Convert.ToString(basicUtil.GetRandomNumber(10000000, 100000000,0));
            card.cardType = 1;

            member.cards.Add(card);

            var client = new RestClient("https://10.4.11.78:8443/lod-minor/api/v1/loyalty/members");
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "7b566965-6974-438a-ab06-3b407cae4036");
            //request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer "+token);
            request.AddJsonBody(member);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("undefined", "{\r\n\"birthDate\": \"1982-07-19T16:20:42.7719+00:00\",\r\n\"changedBy\": \"REST Test\",\r\n\"firstName\": \"Tester\",\r\n\"isEmployee\": false,\r\n\"lastName\": \"Tarts\",\r\n\"memberStatus\": \"Active\",\r\n\"middleName\": \"\",\r\n\"password\": \"Password1*\",\r\n\"passwordExpireDate\": \"2018-10-17\",\r\n\"preferredLanguage\": \"en\",\r\n\"zipCode\": \"75124\",\r\n\"username\": \"ttarts\",\r\n\"email\": \"this@that.com\",\r\n\"alternateId\": \"1150730\",\r\n\"cards\": [\r\n  {\r\n    \"isPrimary\": true,\r\n    \"cardNumber\": \"1150730\",\r\n    \"cardType\": 1\r\n  }\r\n]\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            basicUtil.Log(string.Format("{0}",Newtonsoft.Json.JsonConvert.SerializeObject(response.Content)));
        }

        
     
    }
}
