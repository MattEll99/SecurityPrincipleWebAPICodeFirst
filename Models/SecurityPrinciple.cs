using System;
using System.Collections.Generic;

namespace SecurityPrincipleWebAPICodeFirst.Models;

public partial class SecurityPrinciple
{
    public int Id { get; set; }

    public string? ApplicationId { get; set; }

    public string PrincipleType { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<GroupMember> GroupMemberGroups { get; set; } = new List<GroupMember>();

    public virtual ICollection<GroupMember> GroupMemberSecurityPrinciples { get; set; } = new List<GroupMember>();
}
