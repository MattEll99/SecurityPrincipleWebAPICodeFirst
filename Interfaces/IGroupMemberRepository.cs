﻿using SecurityPrincipleWebAPICodeFirst.Models;

namespace SecurityPrincipleWebAPICodeFirst.Interfaces
{
    public interface IGroupMemberRepository
    {
        //Get And Read.
        ICollection<GroupMember> GetAll(string DbContext);
        ICollection<GroupMember> GetGroupMembersByGroupId(int groupId, string DbContext);
        ICollection<GroupMember> GetGroupsBySecurityPrincipleId(int securityPrincipleId, string DbContext);

        //Create
        bool CreateGroupMember(GroupMember groupMember, string DbContext);
        bool Save(string DbContext);

        //Delete
        bool DeleteGroupMember(GroupMember groupMember, string DbContext);
    }
}
