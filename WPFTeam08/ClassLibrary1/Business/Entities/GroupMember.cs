using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    public class GroupMember
    {
        public int _memberID { get; set; }

        public int _userID { get; set; }

        public bool _isAdmin { get; set; }

        public int _groupID { get; set; }

        GroupMember(int memberId, int userId, bool isAdmin, int groupId) 
        {
            _memberID = memberId;
            _userID = userId;
            _isAdmin = isAdmin;
            _groupID = groupId;
        }
        public GroupMember()
        {
            
        }
    }
}
