using System;
using System.Collections.Generic;
using Microsoft.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassLibTeam08.Data.Framework
{
    public class SelectResult : BaseResult
    {
        public string Message { get; set; }
        public DataTable DataTable { get; set; } = new DataTable();

        public SelectResult(bool succeeded)
        { 
            this.Succeeded = succeeded;
        }
        public SelectResult()
        {
            
        }

        public List<Dictionary<string, object>> SerializableData
        {
            get
            {
                if (DataTable == null) return null;

                return DataTable.AsEnumerable()
                    .Select(row => DataTable.Columns.Cast<DataColumn>()
                        .ToDictionary(col => col.ColumnName, col => row[col]))
                    .ToList();
            }
        }

    }
}
