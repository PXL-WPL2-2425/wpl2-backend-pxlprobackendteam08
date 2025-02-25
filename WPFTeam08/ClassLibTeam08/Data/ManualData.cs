using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data
{
    internal class ManualData : SqlServer
    {
        public ManualData()
        {
            TableName = "manuals";
        }
        public string TableName { get; set; }
        public SelectResult Select()
        {
            return base.Select(TableName);
        }

    }
}
