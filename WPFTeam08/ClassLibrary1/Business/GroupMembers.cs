﻿using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Data;
using ClassLibrary08.Data.Framework;

namespace ClassLibrary1.Business
{
    public static class GroupMembers
    {
        public static SelectResult GetMember(int id)
        {
            GroupMemberData data = new GroupMemberData();
            SelectResult result = data.SelectByID(id);
            return result;
        }

        public static DeleteResult DeleteMember(int id)
        {
            GroupMemberData data = new GroupMemberData();
            DeleteResult result = data.DeleteByID(id);
            return result;
        }
    }
}
