using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restest.Models
{
    public class Member
    {
        public class member
        {
            public string birthDate { get; set; }
            public string firstName { get; set; }
            public bool isEmployee { get; set; }
            public string lastName { get; set; }
            public string memberStatus { get; set; }
            public string middleName { get; set; }
            public string namePrefix { get; set; }
            public string nameSuffix { get; set; }
            public string password { get; set; }
            public string preferredLanguage { get; set; }
            public string passwordExpireDate { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string zipCode { get; set; }
            public string username { get; set; }
            public string alternateId { get; set; }
            public List<card> cards { get; set; }
        }
        public class card
        {
            public string cardNumber { get; set; }
            public string dateIssued { get; set; }
            public string dateRegistered { get; set; }
            public string expirationDate { get; set; }
            public bool isPrimary { get; set; }
            public int cardType { get; set; }
        }
    }
}
