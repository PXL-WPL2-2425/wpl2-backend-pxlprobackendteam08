﻿using System;
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
        public DataTable DataTable { get; set; }
    }
}
