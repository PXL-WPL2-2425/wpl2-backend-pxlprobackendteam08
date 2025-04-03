using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public Group(int groupId, string groupName)
        {
            GroupID = groupId;
            GroupName = groupName;
        }

    }
}
