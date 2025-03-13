using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data.Framework
{
    public class InsertResult : BaseResult
    {
        //NewId wordt teruggegeven door SQL Server - Auto Increment
        public int NewId { get; set; }
        public string Message { get; internal set; }
        public bool Success { get; internal set; }
    }
}
