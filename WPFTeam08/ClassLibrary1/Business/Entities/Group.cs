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
        public int MemberID { get; set; }
        public string GroupName { get; set; }
        public string IpAddress { get; set; }

        public Group(int groupId, int memberInt, string groupName, string ipAddress)
        {
            GroupID = groupId;
            MemberID = memberInt;
            GroupName = groupName;
            IpAddress = ipAddress;
        }

    }
}
