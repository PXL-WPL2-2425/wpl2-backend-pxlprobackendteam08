using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    public class Invoice
    {
        private int _invoiseId;
        private int _subscriptionId;
        private DateTime _createDate;
        private bool _statut;
        private DateTime _invoiceDate;
        private DateTime _deletedDate;

        public int InvoiceID
        {
            get { return _invoiseId;}
            set { _invoiseId = value; }
        }

        public int SubscriptionID
        {
            get { return _subscriptionId; } 
            set { _subscriptionId = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public bool Statut
        {
            get { return _statut; }
            set { _statut = value; }
        }

        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }

        public DateTime DeleteDate
        {
            get { return _deletedDate; }
            set { _deletedDate = value; }
        }

        public Invoice(int invoiceId, int subscriptionId, DateTime createDate, bool statut, DateTime invoiceDate, DateTime deleteDate)
        {
            InvoiceID = invoiceId;
            SubscriptionID = subscriptionId;
            CreateDate = createDate;
            Statut = statut;
            InvoiceDate = invoiceDate;
            DeleteDate = deleteDate;
        }

        public override string ToString()
        {
            return $"{InvoiceID} - {CreateDate} - {InvoiceDate}";
        }
    }
}
