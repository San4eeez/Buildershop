using System;
using System.Collections.Generic;

namespace Buildershop.Models;

public partial class Adre
{
    public int Id { get; set; }

    public string? Pvz { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
