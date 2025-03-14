﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data.Framework
{
    public abstract class BaseResult
    {
        private List<string> errors = new List<string>();
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors => errors;
        public string message;
        public void AddError(string error)
        {
            errors.Add(error);
        }
    }
  
}
