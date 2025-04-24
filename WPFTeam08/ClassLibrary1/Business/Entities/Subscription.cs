using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Subscription
    {
        public int _subscriptionID {  get; set; }

        public int _groupID { get; set; }

        public DateTime _startDate { get; set; }

        public DateTime _endDate
        {
            get { return _endDate; }
            set 
            { 
                if (value > _startDate)
                {
                    _endDate = value;
                }
            }
        }

        public DateTime _renewDate
        {
            get { return _renewDate; }
            set 
            {
                if (value > _startDate)
                {
                    _renewDate = value;
                }
            }
        }

        public string _status { get; set; }

        public bool _autoRenewal { get; set; }

        Subscription(int subscriptionID, int groupID, DateTime startDate, DateTime endDate, DateTime renewDate, string status, bool autoRenewal)
        {
            _subscriptionID = subscriptionID;
            _groupID = groupID;
            _startDate = startDate;
            _endDate = endDate;
            _renewDate = renewDate;
            _status = status;
            _autoRenewal = autoRenewal;
        }
        public Subscription()
        {
            
        }
    }
}
