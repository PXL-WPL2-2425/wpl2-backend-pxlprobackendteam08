using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    public class Invoice
    {
        private int _invoiceId;
        private int _userId;
        private int _groupId;
        private DateTime _date;

        public int InvoiceId
        {
            get { return _invoiceId; }
            set { _invoiceId = value; }
        }
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Invoice(int invoiceId, int userId, int groupId, DateTime date)
        {
            InvoiceId = invoiceId;
            UserId = userId;
            GroupId = groupId;
            Date = date;
        }

        public override string ToString()
        {
            return $"{InvoiceId} - {GroupId} - {Date}";
        }
    }
}
