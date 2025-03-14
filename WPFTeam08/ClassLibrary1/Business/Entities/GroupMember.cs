using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class GroupMember
    {
        public int MemberID { get; set; }

        public int UsertID { get; set; }

        public bool IsAdmin { get; set; }

        GroupMember(int memberId, int userId, bool isAdmin) 
        {
            MemberID = memberId;
            UsertID = userId;
            IsAdmin = isAdmin;
        }
    }
}
