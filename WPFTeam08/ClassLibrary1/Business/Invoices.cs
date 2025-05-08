using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClassLibrary1.Data;

namespace ClassLibrary1.Business
{
    public static class Invoices
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SelectResult GetInvoicesByGroup(int groupId)
        {
            var data = new InvoiceData(_configuration);
            SelectResult result = data.SelectByGroupID(groupId);
            return result;
        }

        public static SelectResult GetAllInvoices()
        {
            var data = new InvoiceData(_configuration);
            SelectResult result = data.SelectAll();
            return result;
        }
    }
}
