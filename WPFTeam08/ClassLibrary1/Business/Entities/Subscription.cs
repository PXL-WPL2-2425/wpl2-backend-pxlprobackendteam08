using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Subscription
    {
        DateTime _endDate;
        DateTime _renewDate;
        public int SubscriptionID {  get; set; }

        public int GroupID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (value > StartDate)
                {
                   _endDate = value;
                }
            }
        }

        public DateTime Renewdate
        {
            get { return _renewDate; }
            set
            {
                if (value > StartDate)
                {
                    _renewDate = value;
                }
            }
        }

        public string Status { get; set; }

        public bool AutoRenewal { get; set; }

        Subscription(int subscriptionID, int groupID, DateTime startDate, DateTime endDate, DateTime renewDate, string status, bool autoRenewal)
        {
            SubscriptionID = subscriptionID;
            GroupID = groupID;
            StartDate = startDate;
            EndDate = endDate;
            Renewdate = renewDate;
            Status = status;
            AutoRenewal = autoRenewal;
        }
        public Subscription()
        {

        }
    }
}