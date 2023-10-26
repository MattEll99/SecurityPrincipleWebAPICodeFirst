using System;
using System.Collections.Generic;

namespace SecurityPrincipleWebAPICodeFirst.Models;

public partial class GroupMember
{
    public int GroupId { get; set; }

    public int SecurityPrincipleId { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual SecurityPrinciple Group { get; set; } = null!;

    public virtual SecurityPrinciple SecurityPrinciple { get; set; } = null!;
}
