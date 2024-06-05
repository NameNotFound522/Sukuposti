using System;
using System.Collections.Generic;

namespace Sukuposti.Infrastructure.Models;

public partial class Audit
{
    public uint Id { get; set; }

    public DateTime OperationTime { get; set; }

    public uint? UserId { get; set; }

    public string? TargetClass { get; set; }

    public uint? TargetId { get; set; }

    public byte[]? Changes { get; set; }
}
