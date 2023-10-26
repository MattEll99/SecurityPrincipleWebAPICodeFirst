using System;
using System.Collections.Generic;

namespace SecurityPrincipleWebAPICodeFirst.Models;

public partial class VGroupMember
{
    public int GroupId { get; set; }

    public int MemberId { get; set; }

    public string GroupDisplayName { get; set; } = null!;

    public string MemberDisplayName { get; set; } = null!;

    public string MemberPrincipleType { get; set; } = null!;
}
