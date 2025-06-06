﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    public class GroupMember
    {
        public int MemberID { get; set; }

        public int UserID { get; set; }

        public bool IsAdmin { get; set; }

        public int GroupID { get; set; }

        public string Naam { get; set; }

        GroupMember(int memberId, int userId, bool isAdmin, int groupId, string naam)
        {
            MemberID = memberId;
            UserID = userId;
            IsAdmin = isAdmin;
            GroupID = groupId;
            Naam = naam;
        }
        public GroupMember()
        {
            
        }
    }
}
