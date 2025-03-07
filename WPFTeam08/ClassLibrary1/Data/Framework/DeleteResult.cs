using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary08.Data.Framework
{
    public class DeleteResult : BaseResult
    {
        public DataTable DataTable { get; set; }
    }
}
