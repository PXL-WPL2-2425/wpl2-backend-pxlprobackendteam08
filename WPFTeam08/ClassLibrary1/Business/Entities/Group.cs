using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Group
    {
        public int _groupID { get; set; }
        public string _groupName { get; set; }

        public Group(int groupId, string groupName)
        {
            _groupID = groupId;
            _groupName = groupName;
        }

    }
}
