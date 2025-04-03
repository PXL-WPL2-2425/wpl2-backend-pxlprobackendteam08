using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data.Framework
{
    internal class UserResult : BaseResult
    {
        public UserResult(bool succeeded)
        {
            this.Succeeded = succeeded;
        }

        public UserResult()
        {

        }
    }
}
